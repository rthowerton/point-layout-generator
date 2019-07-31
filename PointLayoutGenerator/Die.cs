using System;

namespace PointLayoutGenerator
{
    /* Struct to represent a single [x,y] coordinate */
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
        /* A die is composed of 5 points, to symbolize its 
         * corners and the center. */
        private Point tl, tr, bl, br, center;

        /* And also a valid flag to check whether the die
         * is within the 150mm radius. */
        private bool valid;

        /* Generic constructor */
        public Die() { }

        /* Constructor */
        public Die(Point a, Point b, Point c, Point d, Point e)
        {
            tl = a;
            tr = b;
            bl = c;
            br = d;
            center = e;
        }

        /* Set the center point value */
        public void setCenter(Point c)
        {
            center = c;
        }
        /* Set the top left point value */
        public void setTopLeft(Point c)
        {
            tl = c;
        }

        /* Set the top right point value */
        public void setTopRight(Point c)
        {
            tr = c;
        }

        /* Set the bottom left point value */
        public void setBotLeft(Point c)
        {
            bl = c;
        }

        /* Set the bottom right point value */
        public void setBotRight(Point c)
        {
            br = c;
        }

        /* Get just the center point */
        public Point getCenter()
        {
            return center;
        }

        /* Get all of the corner values */
        public Point[] getCorners()
        {
            Point[] corners = new Point[4];
            corners[0] = tl;
            corners[1] = tr;
            corners[2] = bl;
            corners[3] = br;
            return corners;
        }

        /* Check to see if a square is wholly within the 150mm radius */
        public void isValid()
        {
            Point[] corners = this.getCorners();
            foreach (Point corner in corners)
            {
                // Pythagorean theorem
                if ((corner.x * corner.x) + (corner.y * corner.y) > (Generator.radius * Generator.radius))
                {
                    valid = false;
                    break;
                }
                else
                    valid = true;
            }
        }

        /* Return the valid flag */
        public bool getValid()
        {
            return valid;
        }
    }
}