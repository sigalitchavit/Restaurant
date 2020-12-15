using System;
using System.Runtime.Serialization;

namespace RestWebApi
{
    /// <summary>
    /// an empty example to a specialized exception that can be used to throw from this project,
    /// so that it can have a separate handling on the calling code based on the logic of this application.
    /// </summary>
    [Serializable]
    public class DishesException : Exception
    {
        public DishesException()
        {
        }

        public DishesException(string message) : base(message)
        {
        }

        public DishesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DishesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}