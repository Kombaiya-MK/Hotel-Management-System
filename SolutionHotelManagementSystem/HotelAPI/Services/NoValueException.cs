using System.Runtime.Serialization;

namespace HotelAPI.Services
{
    [Serializable]
    internal class NoValueException : Exception
    {
        public string message = "The given item is NULL";
        public NoValueException()
        {
        }

        public NoValueException(string? message) : base(message)
        {

        }

    }
}