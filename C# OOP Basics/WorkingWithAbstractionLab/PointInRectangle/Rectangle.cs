using System;
using System.Collections.Generic;
using System.Text;

public class Rectangle
{
    private Point topLeftPoint;

    public Point TopLeftPoint
    {
        get { return topLeftPoint; }
        set { topLeftPoint = value; }
    }

    private Point bottomRightPoint;

    public Point BottomRightPoint
    {
        get { return bottomRightPoint; }
        set { bottomRightPoint = value; }
    }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        TopLeftPoint = topLeft;
        BottomRightPoint = bottomRight;
    }

    public bool Contains(Point point)
    {
        if (point.X>=TopLeftPoint.X && point.X <= BottomRightPoint.X && point.Y>=TopLeftPoint.Y && point.Y<=BottomRightPoint.Y)
        {
            return true;
        }
        return false;
    }

}
