using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicPackage
{

    //https://ieeexplore.ieee.org/document/4055918
    class Ellips : Shape
    {

        private double yLength;
        private double xLength;
        private int originX;
        private int originY;
        private int x;
        private int y;
        private double dx;
        private double dy;
        private double decisionParameter;

        public Ellips(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            pointsCoordinates = new int[2];
            SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);    
        }

        protected override void SetCoordinates(int mouseDownX, int mouseDownY, int mouseUpX, int mouseUpY)
        {
            base.SetCoordinates(mouseDownX, mouseDownY, mouseUpX, mouseUpY);

            originX = (mouseDownX + mouseUpX) / 2;
            originY = (mouseDownY + mouseUpY) / 2;

            xLength = pointsCoordinates[0] = Math.Abs(mouseDownX - mouseUpX) / 2;
            yLength = pointsCoordinates[1] = Math.Abs(mouseDownY - mouseUpY) / 2;
        }

        public override void Draw(Graphics g, Pen pen)
        {
            x = 0;
            y = (int)yLength;
            decisionParameter = yLength * yLength + (xLength * xLength) / 4 - yLength * xLength * xLength;
            dx = 2 * x * yLength * yLength;
            dy = 2 * y * xLength * xLength;
            DrawRegionOne(g, pen.Brush);
            decisionParameter = ((yLength * yLength) * ((x + 0.5f) * (x + 0.5f))) + ((xLength * xLength) *
                                ((y - 1) * (y - 1))) - (xLength * xLength * yLength * yLength);
            DrawRegionTwo(g, pen.Brush);
        }

        private void DrawRegionOne(Graphics g, Brush brush)
        {
            while (dx < dy)
            {
                DrawPixels(g, brush);
                x++;
                if (decisionParameter < 0)
                {
                    dx += (2 * yLength * yLength);
                    decisionParameter += dx + (yLength * yLength);
                }
                else
                {
                    y--;
                    dx += (2 * yLength * yLength);
                    dy -= (2 * xLength * xLength);
                    decisionParameter += dx - dy + (yLength * yLength);
                }
            }
        }

        private void DrawRegionTwo(Graphics g, Brush brush)
        {
            while (y >= 0)
            {
                DrawPixels(g, brush);
                y--;
                if (decisionParameter > 0)
                {
                    dy = dy - (2 * xLength * xLength);
                    decisionParameter += (xLength * xLength) - dy;
                }
                else
                {
                    x++;
                    dx += (2 * yLength * yLength);
                    dy -= (2 * xLength * xLength);
                    decisionParameter += dx - dy + (xLength * xLength);
                }
            }
        }

        private void DrawPixels(Graphics g, Brush brush)
        {
            g.FillRectangle(brush, originX + x, originY + y, 1, 1);
            g.FillRectangle(brush, originX - x, originY + y, 1, 1);
            g.FillRectangle(brush, originX + x, originY - y, 1, 1);
            g.FillRectangle(brush, originX - x, originY - y, 1, 1);
        }

        public override void ShiftShape(int xShift, int yShift)
        {
            originX -= xShift;
            originY -= yShift;
        }

        public override void Scale(int scalar, bool x, bool y)
        {
            base.Scale(scalar, x, y);
            if (x)
            {
                xLength += scalar;
            }
            else if (y)
            {
                yLength += scalar;
            }
        }
        public override void Rotate(float angle) {}
    }
}
