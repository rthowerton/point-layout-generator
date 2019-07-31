using System;

namespace PointLayoutGenerator
{
    public struct Point
    {
        public float x, y;

        public Point(float p1, float p2)
        {
            x = p1;
            y = p2;
        }
    }

    class Die
    {
        private Point tl, tr, bl, br, center;
        private bool valid;

        public Die() { }

        public Die(Point a, Point b, Point c, Point d, Point e)
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
                {
                    valid = false;
                    break;
                }
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