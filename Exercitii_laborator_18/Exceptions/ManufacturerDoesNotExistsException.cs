using System.Runtime.Serialization;

namespace Exercitii_laborator_18.Exceptions
{
    [Serializable]
    internal class ManufacturerDoesNotExistsException : Exception
    {
        const string message = "Manufacturer does not exists";


        public ManufacturerDoesNotExistsException() : base(message)
        {
        }
    }
}