using Exercitii_laborator_18;
using Exercitii_laborator_18.Data;
using Exercitii_laborator_18.Models;
using Microsoft.EntityFrameworkCore;


#region Cerinte
/*
Un autovehicul este caracterizat de urmatoarele proprietati
    • Id:int
    • Nume
    • Producator
    • Un numar variabil de chei (de la una la oricate)
    • O carte tehnica

Cartea tehnica va avea urmatoarele:
    • Id:int
    • Capacitate cilindrica:int
    • An de fabricatie:int
    • Serie de sasiu: string

Producatorul va avea
    • Id:int
    • Nume
    • Adresa:string
    • O cheie va avea urmatoarele caracteristici
    • Id (int)
    • Cod de acces: Guid unic

Creati modelul, Adaugati DB, populati DB

Scrieti urmatoarele metode
    • Adaugare autovehicul
    • Adaugare producator
    • Adaugare cheie unui autovehicul
    • Inlocuire carte tehnica
    • Stergere autovehicul
    • Stergere producator
    • Stergere cheie

Determinati relatiile necesare

Determinati delete propagation-ul necesar pentru fiecare relatie in parte
*/
#endregion


ResetDB();


using var context = new CarDealerContextDB();

DataLayer.AddAutovehicle("Mazda RX-8", null, null, 3500, 2005, "JAP3453232");
DataLayer.AddManufacturer("Mazda", "Fuchu Japan");
DataLayer.AddAutovehicleKeys(11, 3);
DataLayer.AddManufacturerToAutovehicle(11, 5);
DataLayer.AddOrReplaceVehicleIdentificationCard(10, 1300, 2023, "JAP1112222333");
DataLayer.AddOrReplaceVehicleIdentificationCard(6, 3500, 2018, "WAUZZZ885320147");
DataLayer.RemoveAutovehicle(4);
DataLayer.RemoveManufacturer(1);
DataLayer.RemoveAutovehicleKey(16);
//DataLayer.RemoveAutovehicleKey(17);

var mazdaRx8 = context.Autovehicles.Include(a => a.Keys).First(a => a.AutovehicleId == 11);
foreach(var key in mazdaRx8.Keys)
{
    Console.WriteLine(key.KeyId);
}


static void ResetDB()
{
    using var context = new CarDealerContextDB();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();


    #region Manufacturers
    Manufacturer vwAG = new Manufacturer
    {
        Name = "Volkswagen AG",
        Address = "Wolfsburg Germany"
    };

    Manufacturer honda = new Manufacturer
    {
        Name = "Honda",
        Address = "Minato Japan"
    };

    Manufacturer ford = new Manufacturer
    {
        Name = "Ford",
        Address = "Michigan USA"
    };

    Manufacturer toyota = new Manufacturer
    {
        Name = "Toyota",
        Address = "Aichi Japan"
    };
    #endregion


    #region Autovehicles
    context.Add(new Autovehicle
    {
        Name = "Audi A3",
        Manufacturer = vwAG,
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 2000, ManufacturingYear = 2013, VIN = "WAUZZZ378499212" },
        Keys = new List<Key> { new Key() }
    });

    context.Add(new Autovehicle
    {
        Name = "Honda Jazz",
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 800, ManufacturingYear = 2010, VIN = "LJCPC753829438378499212" },
    });

    context.Add(new Autovehicle
    {
        Name = "Golf 7 Plus",
        Manufacturer = vwAG,
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 2000, ManufacturingYear = 2013, VIN = "VWWZZZ584521557" }
    });

    context.Add(new Autovehicle
    {
        Name = "Toyota Corolla",
        Manufacturer = toyota,
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 1800, ManufacturingYear = 2017, VIN = "JT4RN12P7K84448" },
        Keys = new List<Key> { new Key(), new Key() }
    });

    context.Add(new Autovehicle
    {
        Name = "Mustang",
        Manufacturer = ford,
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 4000, ManufacturingYear = 2019, VIN = "1FX6P8XXH96884" },
        Keys = new List<Key> { new Key(), new Key(), new Key(), new Key() }
    });

    context.Add(new Autovehicle
    {
        Name = "Audi A7",
        Manufacturer = vwAG,
        Keys = new List<Key> { new Key() }
    });

    context.Add(new Autovehicle
    {
        Name = "Toyota Celica",
        Manufacturer = toyota,
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 2300, ManufacturingYear = 1999, VIN = "JT4RN985LC78554" },
        Keys = new List<Key> { new Key(), new Key() }
    });

    context.Add(new Autovehicle
    {
        Name = "Audi A4",
        Manufacturer = vwAG,
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 2400, ManufacturingYear = 2010, VIN = "WAUZZZ73326770" },
        Keys = new List<Key> { new Key() }
    });

    context.Add(new Autovehicle
    {
        Name = "Toyota Prius",
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 1500, ManufacturingYear = 2011, VIN = "JT4RN12K2213421" },
        Keys = new List<Key> { new Key() }
    });

    context.Add(new Autovehicle
    {
        Name = "Honda Civic",
        Manufacturer = honda,
        VehicleIdentificationCard = new VehicleIdentificationCard { CylinderCapacity = 1000, ManufacturingYear = 2022, VIN = "LJCPC75KX899975" },
        Keys = new List<Key> { new Key(), new Key(), new Key() }
    });
    #endregion


    context.SaveChanges();
}