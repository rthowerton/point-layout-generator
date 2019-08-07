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
        /* Radius of wafer */
        public const int radius = 150;

        /* Array to hold a square grid of dice */
        private Die[,] dice;

        /* Variables to track dimensions of the grid */
        private int dieWidth, dieHeight, gridDimensionX, gridDimensionY;
        private float[] xLowHigh, yLowHigh;
        
        /* Variables to track location within grid */
        private int xCoord, yCoord;

        /* Layout Strategy Trackers */
        private string layoutStrategy;
        private int numPoints;

        public Generator()
        {
            InitializeComponent();
        }

        /* When loading the form, set the possible layouts
         * (in the dropdown) to the two strategies. Then,
         * set the current layout to the first strategy.
         * Following, set both the width and height values
         * of the layout to their minimum value of 2
         */
        private void Generator_Load(object sender, EventArgs e)
        {
            string[] layouts = { "Rectangular", "Circular" };
            layoutOptionsBox.Items.AddRange(layouts);
            layoutOptionsBox.SelectedIndex = 0;
            dieWidthInput.Value = dieWidthInput.Minimum;
            dieHeightInput.Value = dieHeightInput.Minimum;
        }

        /* When the layout dropdown selection is changed,
         * depending on the index, hide the other option's
         * corresponding numeric input, show the current
         * numeric input, and take note of the inputs.
         */
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

        /* When the die width input is changed, perform
         * calculations on the new value (specifically,
         * calculate the number of die in the X direction,
         * and calculate the centerpoint of the left-most
         * and right-most complete dice.
         */
        private void DieWidthInput_ValueChanged(object sender, EventArgs e)
        {
            dieWidth = (int)dieWidthInput.Value;
            gridDimensionX = getXDimension(dieWidth);
            xLowHigh = getLowHigh(dieWidth);
        }

        /* When the die height input is changed, perform
         * calculations on the new value (specifically,
         * calculate the number of die in the Y direction,
         * and calculate the centerpoint of the top-most
         * and bottom-most complete dice.
         */
        private void DieHeightInput_ValueChanged(object sender, EventArgs e)
        {
            dieHeight = (int)dieHeightInput.Value;
            gridDimensionY = getYDimension(dieHeight);
            yLowHigh = getLowHigh(dieHeight);
        }

        /* When the number of points the user wants is
         * changed, immediately take note of that value.
         * Just in case.
         */
        private void NumPointsRectangle_ValueChanged(object sender, EventArgs e)
        {
            numPoints = (int)numPointsRectangle.Value;
        }

        /* See above */
        private void NumPointsCircle_ValueChanged(object sender, EventArgs e)
        {
            numPoints = (int)numPointsCircle.Value;
        }

        /* Get the total number of dice along the
         * X-axis, ensuring that the value is always
         * odd, so that the center die is always at
         * [0,0].
         */
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

        /* Get the total number of dice along the
         * Y-axis, ensuring that the value is always
         * odd, so that the center die is always at
         * [0,0].
         */
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

        /* Based on the axis supplied to the function,
         * returns the minimum and maximum values for
         * the inevitable for-loop. If the width or
         * height supplied cleanly divides into the 150mm
         * radius, then the min and max are the radius.
         * Otherwise, find the next largest number that 
         * the width or height cleanly divides into, and
         * return that.
         */
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

        /* Based on the valid flag, prints a point
         * on the chart dieVisualizer corresponding
         * to the current die's center point.
         */
        private void showValidDie(Die d)
        {
            if (d.getValid())
            {
                dieVisualizer.Series[0].Points.AddXY(d.getCenter().x, d.getCenter().y);
            }
        }

        /* Based on the valid flag, highlight the
         * point passed in to show that that point
         * is going to be inspected, and add the
         * coordinates of the point to the text box.
         */
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

        /* When the plotWafer button is clicked,
         * this function takes in the user input
         * and prints the center points of all
         * valid dice to the dieVisualizer chart.
         */
        private void PlotButton_Click(object sender, EventArgs e)
        {
            // Clear all points on the old wafer
            dieVisualizer.Series[0].Points.Clear();
            dieVisualizer.Series[1].Points.Clear();

            dice = new Die[gridDimensionX, gridDimensionY];

            // Set the gridlines to show the edges of the dice.
            // Has the added effect of further cluttering the chart
            // for purposes of obfuscation
            dieVisualizer.ChartAreas[0].AxisX.Interval = dieWidth;
            dieVisualizer.ChartAreas[0].AxisX.IntervalOffset = dieWidth / 2;
            dieVisualizer.ChartAreas[0].AxisY.Interval = dieHeight;
            dieVisualizer.ChartAreas[0].AxisY.IntervalOffset = dieHeight / 2;

            // Fill in array, using xCoord and yCoord to reference the
            // array later.
            xCoord = 0;
            for (float i = xLowHigh[0]; i <= xLowHigh[1]; i += dieWidth)
            {
                yCoord = 0;
                for (float j = yLowHigh[0]; j <= yLowHigh[1]; j += dieHeight)
                {
                    // Create 5 new points that define the current die
                    Point bl = new Point(i - (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                    Point br = new Point(i + (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                    Point tl = new Point(i - (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                    Point tr = new Point(i + (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                    Point center = new Point(i, j);

                    // Create the new die and validate it
                    Die d = new Die(tl, tr, bl, br, center);
                    d.isValid();

                    // If the die is valid, it will be printed
                    showValidDie(d);

                    // Actually add the die to the array
                    dice[xCoord, yCoord] = d;
                    yCoord++;
                }
                xCoord++;
            }

            //testCoords();
        }

        /* If this is the first button clicked, it will
         * do the same as the plotWafer button click,
         * generating an initial array. It will then highlight
         * inspection points on the wafer. If it is not
         * the first button clicked, it will just take
         * the current array and highlight the inspection
         * points based on user input.
         */
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            // Clear just the current inspection points
            dieVisualizer.Series[1].Points.Clear();
            // And the text box
            coordBox.Text = "";

            if (dice == null)
            {
                dice = new Die[gridDimensionX, gridDimensionY];

                // Set the gridlines to show the edges of the dice.
                dieVisualizer.ChartAreas[0].AxisX.Interval = dieWidth;
                dieVisualizer.ChartAreas[0].AxisX.IntervalOffset = dieWidth / 2;
                dieVisualizer.ChartAreas[0].AxisY.Interval = dieHeight;
                dieVisualizer.ChartAreas[0].AxisY.IntervalOffset = dieHeight / 2;

                // Fill in array
                xCoord = 0;
                // For the current release of the app,
                // ic and jc exist to evenly space inspection points.
                int ic = 0, jc = 0;
                for (float i = xLowHigh[0]; i <= xLowHigh[1]; i += dieWidth)
                {
                    yCoord = 0;
                    for (float j = yLowHigh[0]; j <= yLowHigh[1]; j += dieHeight)
                    {
                        // Create 5 new points that define the current die
                        Point bl = new Point(i - (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                        Point br = new Point(i + (float)(dieWidth / 2), j - (float)(dieHeight / 2));
                        Point tl = new Point(i - (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                        Point tr = new Point(i + (float)(dieWidth / 2), j + (float)(dieHeight / 2));
                        Point center = new Point(i, j);

                        // Create the new die and validate it
                        Die d = new Die(tl, tr, bl, br, center);
                        d.isValid();

                        // If the die is valid, it will be printed
                        showValidDie(d);
                        // Check to make sure that the point is evenly spaced
                        // then highlight it if it is valid
                        if (ic % numPoints == 0 && jc % numPoints == 0)
                            showInspectedDie(d);

                        // Actually add the die to the array
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
                // Simply run through the current array
                // and highlight dice at the correct interval
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

        /* This function just builds some strings of
         * coordinates and valid checks and prints
         * them to the text box, like a unit test.
         */
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
