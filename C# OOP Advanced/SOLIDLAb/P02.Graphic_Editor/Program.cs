using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            List<IShape> shapes = new List<IShape>(){new Circle(), new Polygon(), new Rectangle(), new Square()};
            foreach (var shape in shapes.OrderBy(sh=>sh.Type))
            {
                graphicEditor.DrawShape(shape);
            }
        }
    }
}
