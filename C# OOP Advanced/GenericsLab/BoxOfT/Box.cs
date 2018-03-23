using System;
using System.Collections.Generic;
using System.Text;


public class Box<T>
{
    private Stack<T> items;

    public Box()
    {
        this.items = new Stack<T>();
    }

    public int Count => this.items.Count;

    public void Add(T item)
    {
        this.items.Push(item);
    }

    public T Remove()
    {
        return this.items.Pop();
    }
}

