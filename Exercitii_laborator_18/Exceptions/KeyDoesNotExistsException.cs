
namespace Exercitii_laborator_18.Exceptions
{
    [Serializable]
    internal class KeyDoesNotExistsException : Exception
    {
        const string message = "Key does not exists";

        public KeyDoesNotExistsException() : base(message)
        {
        }
    }
}