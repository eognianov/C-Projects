using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle : Shape
{
    private double height;

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    private double width;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public Rectangle(double height, double width)
    {
        this.Height = height;
        this.Width = width;
    }

    public override double CalculatePerimeter()
    {
        double result = (2 * this.Width) +(2 * this.Height);
        return result;
    }

    public override double CalculateArea()
    {
        double result = this.Width * this.Height;
        return result;
    }

    public override string Draw()
    {
        return base.Draw() + "Rectangle";
    }
}

