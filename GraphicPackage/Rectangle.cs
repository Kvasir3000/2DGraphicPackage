using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GraphicPackage
{
    class Rectangle : Shape
    {   
        public Rectangle(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            pointsCoordinates = new int[8];
            linesTable = new int[] {0, 2, 4, 6, 0, 4, 2, 6};
            SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
        }

        // 1    2
        // 3    4
        protected override void SetCoordinates(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            base.SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            if (mouseDownX > mouseUpX)
            {
                pointsCoordinates[0] = mouseUpX;
                pointsCoordinates[2] = mouseDownX;
                pointsCoordinates[4] = mouseUpX;
                pointsCoordinates[6] = mouseDownX;
            }
            else
            {
                pointsCoordinates[0] = mouseDownX;
                pointsCoordinates[2] = mouseUpX;
                pointsCoordinates[4] = mouseDownX;
                pointsCoordinates[6] = mouseUpX;
            }

            if (mouseDownY > mouseUpY)
            {
                pointsCoordinates[1] = mouseUpY;
                pointsCoordinates[3] = mouseUpY;
                pointsCoordinates[5] = mouseDownY;
                pointsCoordinates[7] = mouseDownY;
            }
            else
            {
                pointsCoordinates[1] = mouseDownY;
                pointsCoordinates[3] = mouseDownY;
                pointsCoordinates[5] = mouseUpY;
                pointsCoordinates[7] = mouseUpY;
            }
            middleX = (pointsCoordinates[0] + pointsCoordinates[2]) / 2;
            middleY = (pointsCoordinates[1] + pointsCoordinates[5]) / 2;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            base.Draw(g, pen);
        }

        public override void Scale(int scalar, bool x, bool y)
        {
            base.Scale(scalar, x, y);
            if (x)
            {
                pointsCoordinates[0] = pointsCoordinates[4] -= scalar;
                pointsCoordinates[2] = pointsCoordinates[6] += scalar;
            }

            if (y)
            {
                pointsCoordinates[1] = pointsCoordinates[3] -= scalar;
                pointsCoordinates[5] = pointsCoordinates[7] += scalar;
            }
        }

        public override void Rotate(float angle)
        {
            base.Rotate(angle);
            //pointsCoordinates[0] = 3;
            //pointsCoordinates[1] = 6;
            //pointsCoordinates[2] = 7;
            //pointsCoordinates[3] = 6;
            //pointsCoordinates[4] = 3;
            //pointsCoordinates[5] = 8;
            //pointsCoordinates[6] = 7;
            //pointsCoordinates[7] = 8;
        }

    }
}
