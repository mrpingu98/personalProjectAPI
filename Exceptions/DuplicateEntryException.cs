using System;
using personalProjectAPI.Domains;

namespace personalProjectAPI.Exceptions
{
	public class DuplicateEntryException : Exception
    {
		public DuplicateEntryException(string item) : base($"{item} already exists") { }
	}
}

