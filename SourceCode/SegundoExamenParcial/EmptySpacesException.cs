using System;

namespace SegundoExamenParcial
{
    public class EmptySpacesException : Exception
    {
        public EmptySpacesException(string message) : base(message)
        {
        }
    }
}