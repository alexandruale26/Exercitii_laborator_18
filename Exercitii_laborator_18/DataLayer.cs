using Exercitii_laborator_18.Models;
using Exercitii_laborator_18.Data;
using Exercitii_laborator_18.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Exercitii_laborator_18
{
    internal static class DataLayer
    {
        internal static int AddAutovehicle(string name, int? manufacturerId, int? numberOfKeys, int cylinderCapacity, int manufacturingYear, string vin)
        {
            using var context = new CarDealerContextDB();

            List<Key> newKeys = new List<Key>();
            for (int i = 0; i < numberOfKeys; i++)
            {
                newKeys.Add(new Key());
            }

            var newVic = CreateVIC(cylinderCapacity, manufacturingYear, vin);

            var newAuto = new Autovehicle
            {
                Name = name,
                ManufacturerId = manufacturerId,
                Keys = newKeys,
                VehicleIdentificationCard = newVic
            };

            context.Autovehicles.Add(newAuto);
            context.SaveChanges();
            return newAuto.AutovehicleId;
        }

        internal static int AddManufacturer(string name, string address)
        {
            using var context = new CarDealerContextDB();

            var newManufacturer = new Manufacturer
            {
                Name = name,
                Address = address
            };

            context.Manufacturers.Add(newManufacturer);
            context.SaveChanges();
            return newManufacturer.ManufacturerId;
        }

        internal static List<Key> AddAutovehicleKeys(int autovehicleId, int numberOfKeys)
        {
            using var context = new CarDealerContextDB();

            if (!context.Autovehicles.Any(a => a.AutovehicleId == autovehicleId))
            {
                throw new VehicleDoesNotExistsException();
            }

            if (numberOfKeys < 1)
            {
                throw new InvalidNumberOfKeys();
            }

            List<Key> newKeys = new List<Key>();
            for (int i = 0; i < numberOfKeys; i++)
            {
                newKeys.Add(new Key());
            }

            context.Autovehicles.First(a => a.AutovehicleId == autovehicleId).Keys = newKeys;
            context.SaveChanges();
            return newKeys;
        }

        internal static void AddManufacturerToAutovehicle(int autovehicleId, int manufacturerId)
        {
            using var context = new CarDealerContextDB();

            if (!context.Autovehicles.Any(a => a.AutovehicleId == autovehicleId))
            {
                throw new VehicleDoesNotExistsException();
            }

            if (!context.Manufacturers.Any(a => a.ManufacturerId == manufacturerId))
            {
                throw new ManufacturerDoesNotExistsException();
            }

            context.Autovehicles.First(a => a.AutovehicleId == autovehicleId).ManufacturerId = manufacturerId;
            context.SaveChanges();
        }

        internal static VehicleIdentificationCard AddOrReplaceVehicleIdentificationCard(int autovehicleId, int cylinderCapacity, int manufacturingYear, string vin)
        {
            using var context = new CarDealerContextDB();

            if (!context.Autovehicles.Any(a => a.AutovehicleId == autovehicleId))
            {
                throw new VehicleDoesNotExistsException();
            }

            var newVic = CreateVIC(cylinderCapacity, manufacturingYear, vin);

            var auto = context.Autovehicles.Include(a => a.VehicleIdentificationCard).First(a => a.AutovehicleId == autovehicleId);
            var oldVic = auto.VehicleIdentificationCard;

            if (oldVic != null) context.VehicleIdentificationCards.Remove(oldVic);

            auto.VehicleIdentificationCard = newVic;

            context.SaveChanges();
            return newVic;
        }

        internal static int RemoveAutovehicle(int autovehicleId)
        {
            using var context = new CarDealerContextDB();

            if (!context.Autovehicles.Any(a => a.AutovehicleId == autovehicleId))
            {
                throw new VehicleDoesNotExistsException();
            }

            var auto = context.Autovehicles.Include(a => a.VehicleIdentificationCard).First(a => a.AutovehicleId == autovehicleId);
            var oldVic = auto.VehicleIdentificationCard;

            if (oldVic != null) context.VehicleIdentificationCards.Remove(oldVic);

            context.Remove(auto);
            context.SaveChanges();
            return autovehicleId;
        }

        internal static int RemoveManufacturer(int manufacturerId)
        {
            using var context = new CarDealerContextDB();

            if (!context.Manufacturers.Any(a => a.ManufacturerId == manufacturerId))
            {
                throw new ManufacturerDoesNotExistsException();
            }

            var manufacturerToRemove = context.Manufacturers.First(m => m.ManufacturerId == manufacturerId);
            context.Autovehicles.Include(a => a.Manufacturer).Where(a => a.ManufacturerId == manufacturerId).ToList().ForEach(a => a.Manufacturer = null);
            context.Manufacturers.Remove(manufacturerToRemove);

            context.SaveChanges();
            return manufacturerId;
        }

        internal static int RemoveAutovehicleKey(int keyId)
        {
            using var context = new CarDealerContextDB();

            if (!context.Keys.Any(a => a.KeyId == keyId))
            {
                throw new KeyDoesNotExistsException();
            }

            context.Keys.Remove(context.Keys.First(m => m.KeyId == keyId));
            context.SaveChanges();
            return keyId;
        }


        static private VehicleIdentificationCard CreateVIC(int cylinderCapacity, int manufacturingYear, string vin)
        {
            var newVic = new VehicleIdentificationCard
            {
                CylinderCapacity = cylinderCapacity,
                ManufacturingYear = manufacturingYear,
                VIN = vin
            };
            return newVic;
        }
    }
}
