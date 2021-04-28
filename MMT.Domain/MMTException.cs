using System;

namespace MMT.Domain
{
	public class MMTException : Exception
	{
		public MMTException(string message) : base(message)
		{

		}
	}

	public class MMTArgumentNullException : ArgumentNullException
	{
		public MMTArgumentNullException(string parameter) : base(parameter)
		{

		}
	}
}
