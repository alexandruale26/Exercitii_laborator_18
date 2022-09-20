
namespace Exercitii_laborator_18.Exceptions
{
    [Serializable]
    internal class VehicleDoesNotExistsException : Exception
    {
        const string message = "Vehicle does not exists";

        public VehicleDoesNotExistsException(): base(message)
        {
        }
    }
}