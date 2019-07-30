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
            Point[] corners = this.getCorners();
            foreach (Point corner in corners)
            {
                // Perform the check
                if ((corner.x * corner.x) + (corner.y * corner.y) > (Generator.radius * Generator.radius))
                    valid = false;
                else
                    valid = true;
            }
        }

        public bool getValid()
        {
            return valid;
        }
    }
}
