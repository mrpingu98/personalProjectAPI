using System;
namespace personalProjectAPI.Exceptions
{
	public class EntityNotFoundException : Exception
	{
       private const string DefaultMessage = "Entity was not found";

        public EntityNotFoundException() : base(DefaultMessage)
        {
        }
        //when a class inherits a base class and you make a constructor, the constructor has to be told to also initiliase this base class
        //so have to add ': base' to your constructor
        //here we are making a default TestException, i.e. when no parameters are passed through for it
        //The base class here is the Exception class...and this takes in a message to be displayed as an error
        //e.g. throw new Exception("Error message")
        //so base() is the same as Exception() - and we are passing the default message through to it
        //can imagine the exception class as:


        //public class Exceptions
        //{
        //    public string Message;

        //    public Exceptions(string message)
        //    {
        //        Message = message;
        //    }

        //    code that returns exceptions and uses the message passed through
        //}

        //So when you initialise the TestException class, as it inherits from the Exception class, you need to initialise that as well,
        //and pass through a message to be displayed



        //now want examples where you can pass through custom error messages 

        public EntityNotFoundException(string name) : base($"Item '{name}' was not found"){ }

        //specify an inner exception to be wrapped

        public EntityNotFoundException(Exception innerException, string message) : base(message, innerException) { }
    }
}

