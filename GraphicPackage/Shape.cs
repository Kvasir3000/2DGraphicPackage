using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicPackage
{
    abstract class Shape
    {
        //protected int[,] pointsCoordinates;
        protected int[] linesTable;
        protected int[] pointsCoordinates;

        protected int middleX = 0;
        protected int middleY = 0;
        // This is the base class for Shapes in the application. It should allow an array or LL
        // to be created containing different kinds of shapes.
    

        protected virtual void SetCoordinates(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY) { ; }

        public virtual void Draw(Graphics g, Pen pen) 
        {
            for (int i = 0; i < linesTable.Length; i += 2)
            {
                g.DrawLine(pen, pointsCoordinates[linesTable[i]], pointsCoordinates[linesTable[i] + 1],
                           pointsCoordinates[linesTable[i + 1]], pointsCoordinates[linesTable[i + 1] + 1]
                );
            }
        }

        public virtual void ShiftShape(int xShift, int yShift)
        {
            middleX -= xShift;
            middleY -= yShift;
            for (int i = 0; i < pointsCoordinates.Length; i+= 2)
            {
                pointsCoordinates[i] -= xShift;
                pointsCoordinates[i + 1] -= yShift;
            }
        }

        public virtual void Scale(int scalar, bool x, bool y) { }

        public virtual void Rotate(float angle) {
            for (int i = 0; i < pointsCoordinates.Length; i += 2)
            {
                int tempX = pointsCoordinates[i] - middleX;
                int tempY = middleY - pointsCoordinates[i + 1];

                pointsCoordinates[i] = (int)(tempX * Math.Cos(-angle * Math.PI / 180.0) - tempY * Math.Sin(-angle * Math.PI / 180.0));
                pointsCoordinates[i + 1] = (int)(tempX * Math.Sin(-angle * Math.PI / 180.0)) + (int)(tempY * Math.Cos(-angle * Math.PI / 180.0));


                pointsCoordinates[i] += middleX;
                pointsCoordinates[i + 1] = middleY - pointsCoordinates[i + 1];
            }
        }
    }
}
