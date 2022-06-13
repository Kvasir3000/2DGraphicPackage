using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicPackage
{
    //    2
    //  1   3
    //    4
    class Diamond : Shape
    {
        public Diamond(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            pointsCoordinates = new int[8];
            SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            linesTable = new int[] {0, 2, 2, 4, 4, 6, 6, 0};
        }

        protected override void SetCoordinates(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            base.SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            if (mouseDownX > mouseUpX)
            {
                pointsCoordinates[0] = mouseUpX;
                pointsCoordinates[4] = mouseDownX;
            } 
            else
            {
                pointsCoordinates[0] = mouseDownX;
                pointsCoordinates[4] = mouseUpX;
            }
            pointsCoordinates[2] = pointsCoordinates[6] = (mouseUpX + mouseDownX) / 2;

            if (mouseDownY > mouseUpY)
            {
                pointsCoordinates[3] = mouseUpY;
                pointsCoordinates[7] = mouseDownY;
            }
            else
            {
                pointsCoordinates[3] = mouseDownY;
                pointsCoordinates[7] = mouseUpY;
            }
            pointsCoordinates[1] = pointsCoordinates[5] = (mouseUpY + mouseDownY) / 2;
            middleX = (pointsCoordinates[0] + pointsCoordinates[4]) / 2;
            middleY = (pointsCoordinates[3] + pointsCoordinates[7]) / 2;
        }

        public override void Scale(int scalar, bool x, bool y)
        {
            base.Scale(scalar, x, y);
            if (x)
            {
                pointsCoordinates[0] -= scalar;
                pointsCoordinates[4] += scalar;
            }
           
            if (y)
            {
                pointsCoordinates[3] -= scalar;
                pointsCoordinates[7] += scalar;
            }
        }
    }
}
