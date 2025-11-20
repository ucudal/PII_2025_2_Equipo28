using System;

namespace Library
{
        public class InvalidDateException : Exception
        {
            public InvalidDateException(string mensaje=null,string parametro=null): base(mensaje){}
        }

}