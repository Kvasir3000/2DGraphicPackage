using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicPackage
{
    // 2
    // 1    3
    class RightTriangle : Shape
    {
        public RightTriangle(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            pointsCoordinates = new int[6];
            SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            linesTable = new int[] { 0, 2, 2, 4, 4, 0};
        }

        protected override void SetCoordinates(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            base.SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            if (mouseDownX > mouseUpX)
            {
                pointsCoordinates[0] = mouseUpX;
                pointsCoordinates[2] = mouseUpX;
                pointsCoordinates[4] = mouseDownX;
            } 
            else
            {
                pointsCoordinates[0] = mouseDownX;
                pointsCoordinates[2] = mouseDownX;
                pointsCoordinates[4] = mouseUpX;
            }

            if (mouseDownY > mouseUpY)
            {
                pointsCoordinates[1] = mouseDownY;
                pointsCoordinates[3] = mouseUpY;
                pointsCoordinates[5] = mouseDownY;
            }
            else
            {
                pointsCoordinates[1] = mouseUpY;
                pointsCoordinates[3] = mouseDownY;
                pointsCoordinates[5] = mouseUpY;
            }
            middleX = (pointsCoordinates[0] + pointsCoordinates[4]) / 2;
            middleY = (pointsCoordinates[1] + pointsCoordinates[3]) / 2;
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
                pointsCoordinates[0] -= scalar;
                pointsCoordinates[2] -= scalar;
                pointsCoordinates[4] += scalar;
            } 
            if (y)
            {
                pointsCoordinates[1] += scalar;
                pointsCoordinates[3] -= scalar;
                pointsCoordinates[5] += scalar;
            }
        }
    }

}
