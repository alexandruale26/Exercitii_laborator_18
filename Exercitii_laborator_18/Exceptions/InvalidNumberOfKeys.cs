
namespace Exercitii_laborator_18.Exceptions
{
    [Serializable]
    internal class InvalidNumberOfKeys : Exception
    {
        const string message = "Invalid number of keys";

        public InvalidNumberOfKeys() : base(message)
        {
        }
    }
}