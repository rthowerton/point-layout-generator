//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AlgorithmTest
{
    public struct Point
    {
        public int x, y;

        public Point(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
    class Square
    {
        private Point tl, tr, bl, br, center;
        private bool valid;

        public Square() { }

        public Square(Point a, Point b, Point c, Point d, Point e)
        {
            tl = a;
            tr = b;
            bl = c;
            br = d;
            center = e;
        }

        public void setCenter(Point c)
        {
            center = c;
        }

        public void setTopLeft(Point c)
        {
            tl = c;
        }

        public void setTopRight(Point c)
        {
            tr = c;
        }

        public void setBotLeft(Point c)
        {
            bl = c;
        }

        public void setBotRight(Point c)
        {
            br = c;
        }

        public Point getCenter()
        {
            return center;
        }

        public Point[] getCorners()
        {
            Point[] corners = new Point[4];
            corners[0] = tl;
            corners[1] = tr;
            corners[2] = bl;
            corners[3] = br;
            return corners;
        }

        // Check to see if a square is wholly within the 150mm radius
        public void isValid()
        {
            // Sides of the triangle whose hypoteneuse is 150mm from [0,0]
            int a = 0, b = 0;
            // Determine which quadrant the square is in
            // and account for negative values
            if (center.x > 0 && center.y > 0)
            {
                b = tr.x;
            }
            else if (center.x < 0 && center.y > 0)
            {
                a = tl.y;
                b = tr.x * -1;
            }
            else if (center.x < 0 && center.y < 0)
            {
                a = bl.y * -1;
                b = bl.x * -1;
            }
            else if (center.x > 0 && center.y < 0)
            {
                a = br.y * -1;
                b = br.x;
            }

            // Perform the check
            if ((a * a) + (b * b) > (150 * 150))
                valid = false;
            else
                valid = true;
        }

        public bool getValid()
        {
            return valid;
        }
    }
}
