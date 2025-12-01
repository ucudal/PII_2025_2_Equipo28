using System;

namespace Library
{
        public class InvalidDateException : ArgumentException
        {
            public InvalidDateException(string message=null,string paraName=null): base(message,paraName){}
        }
}