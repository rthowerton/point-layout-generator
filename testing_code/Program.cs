using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AlgorithmTest
{
    class Generator
    {
        public const int radius = 150;
        static void Main(string[] args)
        {
            // Array needs to hold (300 / cell width) + 2 X by
            // (300 / cell height) + 2 Y squares (one square extra on each side)
            // in this instance equivalent to radius + 2
            Square[,] squares = new Square[radius + 2, radius + 2];
            
            // Variables to track location in grid
            int x = 0, y = 0;
            for(int i = -1 * radius; i < radius + 2; i+=2)
            {
                y = 0;
                for(int j = -1 * radius; j < radius + 2; j+=2)
                {
                    Point bl = new Point(i-1, j-1);
                    Point br = new Point(i+1, j-1);
                    Point tl = new Point(i-1, j+1);
                    Point tr = new Point(i+1, j+1);
                    Point center = new Point(i, j);
                    Square s = new Square(tl, tr, bl, br, center);
                    s.isValid();
                    squares[x, y] = s;
                    y++;
                }
                x++;
            }

            Console.Write("[{0},{1}]\n", squares[(x - 1) / 2, (y - 1) / 2].getCenter().x, squares[(x - 1) / 2, (y - 1) / 2].getCenter().y);
            Console.Write("{0}\n", squares[(x - 1) / 2, (y - 1) / 2].getValid());
            Console.Write("[{0},{1}]\n", squares[0, 0].getCenter().x, squares[0, 0].getCenter().y);
            Console.Write("{0}\n", squares[0, 0].getValid());
            Console.Write("[{0},{1}]\n", squares[x-1, y-1].getCenter().x, squares[x-1, y-1].getCenter().y);
            Console.Write("{0}\n", squares[x-1, y-1].getValid());
            Console.Write("[{0},{1}]\n", squares[x / 2, y - 2].getCenter().x, squares[x / 2, y - 2].getCenter().y);
            Console.Write("{0}\n", squares[x / 2, y - 2].getValid());
        }
    }
}
