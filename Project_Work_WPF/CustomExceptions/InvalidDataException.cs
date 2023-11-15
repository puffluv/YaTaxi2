using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Work_WPF.CustomExceptions
{
	class InvalidDataException : Exception
	{ 

		public InvalidDataException() : base(String.Format("Usernasme or Password is Incorrect"))
		{ }
	}
}
