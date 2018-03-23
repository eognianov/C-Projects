using System;
using System.Collections.Generic;
using System.Text;


public static class ArrayCreator
{
    public static T[] Create<T>(int lengt, T item)
    {
        T[] array = new T[lengt];
        for (int i = 0; i < lengt; i++)
        {
            array[i] = item;
        }

        return array;
    }
}

