using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace GraphicPackage
{
    public partial class GraphicPackage : Form
    {
        private bool drawShapeFlag = false;
        private bool selectShapeFlag = false;
        private bool rubberBandingFlag = false;
        private static int mouseDownX, mouseDownY, mouseUpX, mouseUpY;

        public static int scalerValue = 1;
        public static bool xScaleBool = false;
        public static bool yScaleBool = false;

        public static float angle = 0;

        
        Bitmap backBuffer;
        Graphics g, g2;

        ScaleShapeForm scaleWindow = new ScaleShapeForm();
        RotateShapeForm rotateWindow = new RotateShapeForm();

        private enum Shapes
        {
            Square,
            Triangle,
            RightTriangle,
            Diamond,
            Elipse
        }
        Shapes currentShape;

        LinkedList<Shape> shapes = new LinkedList<Shape>();
        int currentlySelectedShapeIdx = 0;

        public GraphicPackage()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.Width = 900;
            this.Height = 760;
            //this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
           
            MainMenu mainMenu = new MainMenu();
           
            // Menu items for creating shapes 
            MenuItem createItem = new MenuItem();
            MenuItem squareItem = new MenuItem();
            MenuItem triangleItem = new MenuItem();
            MenuItem rightTriangleItem = new MenuItem();
            MenuItem diamondItem = new MenuItem();
            MenuItem elipseItem = new MenuItem();

            // Menu items for selecting shapes 
            MenuItem selectItem = new MenuItem();
            MenuItem nextShapeItem = new MenuItem();
            MenuItem previousShapeItem = new MenuItem();
            MenuItem noneShapeItem = new MenuItem();
            MenuItem firstShapeItem = new MenuItem();

            MenuItem transformItem = new MenuItem();
            MenuItem scaleItem = new MenuItem();
            MenuItem rotateItem = new MenuItem();
            MenuItem deleteItem = new MenuItem();

            createItem.Text = "&Create";
            squareItem.Text = "&Rectangle";
            diamondItem.Text = "&Diamond";
            triangleItem.Text = "&Triangle";
            rightTriangleItem.Text = "&Right triangle";
            elipseItem.Text = "&Elipse";
            
            selectItem.Text = "&Select";
            nextShapeItem.Text = "&Next shape";
            previousShapeItem.Text = "&Previous shape";
            noneShapeItem.Text = "&None";
            firstShapeItem.Text = "&First shape";

            scaleItem.Text = "&Scale";
            rotateItem.Text = "&Rotate";
            deleteItem.Text = "&Delete";

            mainMenu.MenuItems.Add(createItem);
            mainMenu.MenuItems.Add(selectItem);
            mainMenu.MenuItems.Add(scaleItem);
            mainMenu.MenuItems.Add(rotateItem);
            mainMenu.MenuItems.Add(deleteItem);

            createItem.MenuItems.Add(squareItem);
            createItem.MenuItems.Add(triangleItem);
            createItem.MenuItems.Add(rightTriangleItem);
            createItem.MenuItems.Add(diamondItem);
            createItem.MenuItems.Add(elipseItem);
            

            selectItem.MenuItems.Add(nextShapeItem);
            selectItem.MenuItems.Add(previousShapeItem);
            selectItem.MenuItems.Add(noneShapeItem);
            selectItem.MenuItems.Add(firstShapeItem);


            squareItem.Click += new System.EventHandler(this.SelectSquare);
            triangleItem.Click += new System.EventHandler(this.SelectTriangle);
            rightTriangleItem.Click += new System.EventHandler(this.SelectRightTriangle);
            diamondItem.Click += new System.EventHandler(this.SelectDiamond);
            elipseItem.Click += new System.EventHandler(this.SelectElipse);

            //selectItem.Click += new System.EventHandler(this.selectShape);
            nextShapeItem.Click += new System.EventHandler(this.SelectNextShape);
            previousShapeItem.Click += new System.EventHandler(this.SelectPreviousShape);
            noneShapeItem.Click += new System.EventHandler(this.SelectNoneShape);
            firstShapeItem.Click += new System.EventHandler(this.SelectFirstShape);


            scaleItem.Click += new System.EventHandler(this.ScaleItem);
            rotateItem.Click += new System.EventHandler(this.RotateItem);
            deleteItem.Click += new System.EventHandler(this.DeleteItem);

            this.Menu = mainMenu;
            backBuffer = new Bitmap(this.Width, this.Height);
            g = this.CreateGraphics();
            g2 = Graphics.FromImage(backBuffer);

        }

        // Generally, all methods of the form are usually private
        private void SelectSquare(object sender, EventArgs e)
        {
            currentShape = Shapes.Square;
            drawShapeFlag = true;
        }

        private void SelectTriangle(object sender, EventArgs e)
        {
            drawShapeFlag = true;
            currentShape = Shapes.Triangle;
        }

        private void SelectDiamond(object sender, EventArgs e)
        {
            drawShapeFlag = true;
            currentShape = Shapes.Diamond;
        }

        private void SelectRightTriangle(object sender, EventArgs e)
        {
            drawShapeFlag = true;
            currentShape = Shapes.RightTriangle;
        }

        private void SelectElipse(object sender, EventArgs e)
        {
            drawShapeFlag = true;
            currentShape = Shapes.Elipse;
        }

        /// <summary>
        ///  Delete!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectShape(object sender, EventArgs e)
        {
            selectShapeFlag = (selectShapeFlag) ? false : true;
        }

        private void SelectNextShape(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                selectShapeFlag = true;
                currentlySelectedShapeIdx = (currentlySelectedShapeIdx < shapes.Count - 1) ? currentlySelectedShapeIdx + 1 : 0;
            }
        }

        private void SelectPreviousShape(object sender, EventArgs e)
        {
            if (shapes.Count > 2)
            {
                selectShapeFlag = true;
                currentlySelectedShapeIdx = (currentlySelectedShapeIdx == 0) ? shapes.Count() - 1 : currentlySelectedShapeIdx - 1;
            }
        }

        private void SelectNoneShape(object sender, EventArgs e)
        {
            if (shapes.Count > 0)  selectShapeFlag = false;
        }

        private void SelectFirstShape(object sender, EventArgs e)
        {
            if (shapes.Count > 0)
            {
                selectShapeFlag = true;
                currentlySelectedShapeIdx = 0;
            }
        }

        public void ScaleItem(object sender, EventArgs e)
        {
            if (!selectShapeFlag)
            {
                MessageBox.Show("Select the shape to perform transformation");
            }
            else
            {
                scaleWindow.ShowDialog();
                shapes.ElementAt(currentlySelectedShapeIdx).Scale(scalerValue, xScaleBool, yScaleBool);
                DrawCreatedShapes();
                g.DrawImage(backBuffer, 0, 0);
            }
        }

        public void RotateItem(object sender, EventArgs  e)
        {
            if (!selectShapeFlag)
            {
                MessageBox.Show("Select the shape to perform rotation");
            } 
            else
            {
                rotateWindow.ShowDialog();
                shapes.ElementAt(currentlySelectedShapeIdx).Rotate(angle);
                DrawCreatedShapes();
                g.DrawImage(backBuffer, 0, 0);
            }
        }

        public void DeleteItem(object sender, EventArgs e)
        {
            if (!selectShapeFlag)
            {
                MessageBox.Show("Select the shape to delete it");
            }
            else
            {
                Shape temp = shapes.ElementAt(currentlySelectedShapeIdx);
                shapes.Remove(temp);
                if (shapes.Count > 0)
                {
                    if (currentlySelectedShapeIdx != 0) currentlySelectedShapeIdx--;
                } 
                else
                {
                    selectShapeFlag = false;
                    currentlySelectedShapeIdx = 0;
                }
                DrawCreatedShapes();
                g.DrawImage(backBuffer, 0, 0);
            }
        }

        private void GraphicPackage_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownX = e.X;
            mouseDownY = e.Y;
            if (e.Button == MouseButtons.Left && drawShapeFlag)
            {
                rubberBandingFlag = true; 
            }
    
        }

        private void GraphicPackage_MouseMove(object sender, MouseEventArgs e)
        {
            if (rubberBandingFlag)
            {
                DrawShape(e);
            }
            else if (selectShapeFlag && e.Button == MouseButtons.Left && shapes.Count > 0)
            {
                ShiftShape(e);
            } 
        } 

        private void DrawShape(MouseEventArgs e)
        {
            mouseUpX = e.X;
            mouseUpY = e.Y;

            Shape tempShape = CreateShape();
            DrawCreatedShapes();
            tempShape.Draw(g2, new Pen(Color.Black));
            g.DrawImage(backBuffer, 0, 0);
        }

    
        private void ShiftShape(MouseEventArgs e)
        {
            int xShift = mouseDownX - e.X;
            int yShift = mouseDownY - e.Y;
            mouseDownX = e.X;
            mouseDownY = e.Y;
            shapes.ElementAt(currentlySelectedShapeIdx).ShiftShape(xShift, yShift);
            DrawCreatedShapes();
            g.DrawImage(backBuffer, 0, 0);
        }

        private void GraphicPackage_MouseUp(object sender, MouseEventArgs e)
        {
            if (rubberBandingFlag)
            {
                rubberBandingFlag = false;
                drawShapeFlag = false;
                Shape newShape = CreateShape();
                shapes.AddLast(newShape);
            }
        }

        private Shape CreateShape()
        {
            if (currentShape == Shapes.Square)
            {
                return new Rectangle(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            }
            else if (currentShape == Shapes.Triangle)
            {
                return new Triangle(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            } 
            else if (currentShape == Shapes.Diamond)
            {
                return new Diamond(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            }
            else if (currentShape == Shapes.RightTriangle)
            {
                return new RightTriangle(mouseDownX, mouseDownY, mouseUpX, mouseUpY); 
            }
            else if (currentShape == Shapes.Elipse)
            {
                return new Ellips(mouseDownX, mouseDownY, mouseUpX, mouseUpY);
            }
            else return null;
        }

        private void DrawCreatedShapes()
        {
            g2.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
            foreach (var shape in shapes)
            {
                shape.Draw(g2, new Pen(new SolidBrush(Color.Black)));
            }
        }
    }
}
