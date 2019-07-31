using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointLayoutGenerator
{
    public partial class Generator : Form
    {
        // Radius of wafer
        public const int radius = 150;

        // Array to hold a square grid of dice
        private Die[,] dice;

        // Variables to track dimensions of the grid
        private int dieWidth, dieHeight, gridDimensionX, gridDimensionY;
        private float[] xLowHigh, yLowHigh;
        
        // Variables to track location in grid
        private int xCoord, yCoord;

        // Layout Strategy Tracker
        private string layoutStrategy;
        private int numPoints;

        public Generator()
        {
            InitializeComponent();
        }

        private void Generator_Load(object sender, EventArgs e)
        {
            string[] layouts = { "Rectangular", "Circular" };
            layoutOptionsBox.Items.AddRange(layouts);
            layoutOptionsBox.SelectedIndex = 0;
            dieWidthInput.Value = dieWidthInput.Minimum;
            dieHeightInput.Value = dieHeightInput.Minimum;
        }

        private void LayoutOptionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(layoutOptionsBox.SelectedIndex == 0)
            {
                numPointsCircle.Visible = false;
                numPointsCircle.Value = numPointsCircle.Minimum;
                numPointsRectangle.Visible = true;
                numPoints = (int)numPointsRectangle.Value;
            }
            else
            {
                numPointsCircle.Visible = true;
                numPoints = (int)numPointsCircle.Value;
                numPointsRectangle.Visible = false;
                numPointsRectangle.Value = numPointsRectangle.Minimum;
            }
            layoutStrategy = layoutOptionsBox.SelectedItem.ToString();
        }

        private void DieWidthInput_ValueChanged(object sender, EventArgs e)
        {
            dieWidth = (int)dieWidthInput.Value;
            gridDimensionX = getXDimension(dieWidth);
            xLowHigh = getLowHigh(dieWidth);
        }

        private void DieHeightInput_ValueChanged(object sender, EventArgs e)
        {
            dieHeight = (int)dieHeightInput.Value;
            gridDimensionY = getYDimension(dieHeight);
            yLowHigh = getLowHigh(dieHeight);
        }

        private void NumPointsRectangle_ValueChanged(object sender, EventArgs e)
        {
            numPoints = (int)numPointsRectangle.Value;
        }

        private void NumPointsCircle_ValueChanged(object sender, EventArgs e)
        {
            numPoints = (int)numPointsCircle.Value;
        }

        private int getXDimension(int dieWidth)
        {
            if (radius % dieWidth == 0)
            {
                return (300 / dieWidth) + 1;
            }
            else
            {
                return 300 / dieWidth;
            }
        }

        private int getYDimension(int dieHeight)
        {
            if (radius % dieHeight == 0)
            {
                return (300 / dieHeight) + 1;
            }
            else
            {
                return 300 / dieHeight;
            }
        }

        private float[] getLowHigh(int dieDimension)
        {
            float[] toReturn = new float[2];
            if(radius % dieDimension == 0)
            {
                toReturn[0] = -1 * radius;
                toReturn[1] = radius;
                return toReturn;
            }
            else
            {
                toReturn[1] = radius - 1;
                while(toReturn[1] % dieDimension != 0)
                {
                    toReturn[1]--;
                }
                toReturn[0] = -1 * toReturn[1];
                return toReturn;
            }
        }

        private void showValidDie(Die d)
        {
            if (d.getValid())
            {
                dieVisualizer.Series[0].Points.AddXY(d.getCenter().x, d.getCenter().y);
            }
        }

        private void showInspectedDie(Die d)
        {
            if (d.getValid())
            {
                dieVisualizer.Series[1].Points.AddXY(d.getCenter().x, d.getCenter().y);
                string text = coordBox.Text;
                text += "[" + d.getCenter().x.ToString() + "," + d.getCenter().y.ToString() + "]";
                coordBox.Text = text;
            }
        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            dieVisualizer.Series[0].Points.Clear();
            dieVisualizer.Series[1].Points.Clear();

            dice = new Die[gridDimensionX, gridDimensionY];

            dieVisualizer.ChartAreas[0].AxisX.Interval = dieWidth;
            dieVisualizer.ChartAreas[0].AxisX.IntervalOffset = dieWidth / 2;
            dieVisualizer.ChartAreas[0].AxisY.Interval = dieHeight;
            dieVisualizer.ChartAreas[0].AxisY.IntervalOffset = dieHeight / 2;

            // Fill in array
            xCoord = 0;
            for (float i = xLowHigh[0]; i <= xLowHigh[1]; i += dieWidth)
            {
                yCoord = 0;
                for (float j = yLowHigh[0]; j <= yLowHigh[1]; j += dieHeight)
                {
                    Point bl = new Point(i - (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                    Point br = new Point(i + (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                    Point tl = new Point(i - (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                    Point tr = new Point(i + (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                    Point center = new Point(i, j);

                    Die d = new Die(tl, tr, bl, br, center);
                    d.isValid();

                    showValidDie(d);

                    dice[xCoord, yCoord] = d;
                    yCoord++;
                }
                xCoord++;
            }

            //testCoords();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            dieVisualizer.Series[1].Points.Clear();

            if (dice == null)
            {
                dice = new Die[gridDimensionX, gridDimensionY];

                dieVisualizer.ChartAreas[0].AxisX.Interval = dieWidth;
                dieVisualizer.ChartAreas[0].AxisX.IntervalOffset = dieWidth / 2;
                dieVisualizer.ChartAreas[0].AxisY.Interval = dieHeight;
                dieVisualizer.ChartAreas[0].AxisY.IntervalOffset = dieHeight / 2;

                // Fill in array
                xCoord = 0;
                int ic = 0, jc = 0;
                for (float i = xLowHigh[0]; i <= xLowHigh[1]; i += dieWidth)
                {
                    yCoord = 0;
                    for (float j = yLowHigh[0]; j <= yLowHigh[1]; j += dieHeight)
                    {
                        Point bl = new Point(i - (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                        Point br = new Point(i + (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                        Point tl = new Point(i - (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                        Point tr = new Point(i + (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                        Point center = new Point(i, j);

                        Die d = new Die(tl, tr, bl, br, center);
                        d.isValid();

                        showValidDie(d);
                        if (ic % numPoints == 0 && jc % numPoints == 0)
                            showInspectedDie(d);

                        dice[xCoord, yCoord] = d;
                        yCoord++;
                        jc++;
                    }
                    xCoord++;
                    ic++;
                }

                //testCoords();
            }
            else
            {
                int ic = 0, jc = 0;
                for (int i = 0; i < xCoord; i++)
                {
                    for (int j = 0; j < yCoord; j++)
                    {
                        Die d = dice[i, j];

                        if (ic % numPoints == 0 && jc % numPoints == 0)
                        {
                            showInspectedDie(d);
                        }
                        jc++;
                    }
                    ic++;
                }
            }
        }

        private void testCoords()
        {
            string test1 = "[" + dice[xCoord / 2, yCoord / 2].getCenter().x.ToString() + "," +
                dice[xCoord / 2, yCoord / 2].getCenter().y.ToString() + "]";
            string test2 = dice[xCoord / 2, yCoord / 2].getValid().ToString();

            string test3 = "[" + dice[xCoord / 2, 1].getCenter().x.ToString() + "," +
                dice[xCoord / 2, 1].getCenter().y.ToString() + "]";
            string test4 = dice[xCoord / 2, 1].getValid().ToString();

            string test5 = "[" + dice[xCoord / 2, 0].getCenter().x.ToString() + "," +
                dice[xCoord / 2, 0].getCenter().y.ToString() + "]";
            string test6 = dice[xCoord / 2, 0].getValid().ToString();

            string test7 = "[" + dice[xCoord - 2, yCoord / 2].getCenter().x.ToString() + "," +
                dice[xCoord - 2, yCoord / 2].getCenter().y.ToString() + "]";
            string test8 = dice[xCoord - 2, yCoord / 2].getValid().ToString();

            coordBox.Text = test1 + "\n" + test2 + "\n"
                + test3 + "\n" + test4 + "\n"
                + test5 + "\n" + test6 + "\n"
                + test7 + "\n" + test8;
        }
    }
}
