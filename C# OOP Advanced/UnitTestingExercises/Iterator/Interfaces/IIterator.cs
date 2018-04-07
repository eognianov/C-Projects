using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Interfaces
{
    public interface IIterator
    {
        bool Move();

        bool HasNext();

        string Print();
    }
}
