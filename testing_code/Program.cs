using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace AlgorithmTest
{
    class Program
    {
        private const int radius = 150;
        static void Main(string[] args)
        {
            Square[,] squares = new Square[radius*2, radius*2];
            int x = 0, y = 0;
            for(int i = -150; i < 150; i++)
            {
                y = 0;
                for(int j = -150; j < 150; j++)
                {
                    Point bl = new Point(i, j);
                    Point br = new Point(i + 2, j);
                    Point tl = new Point(i, j + 2);
                    Point tr = new Point(i + 2, j + 2);
                    Point center = new Point(i + 1, j + 1);
                    Square s = new Square(tl, tr, bl, br, center);
                    s.isValid();
                    squares[x, y] = s;
                    y++;
                }
                x++;
            }

            Console.Write("[{0},{1}]\n", squares[x / 2, y / 2].getCenter().x, squares[x/2,y/2].getCenter().y);
            Console.Write("{0}\n", squares[x / 2, y / 2].getValid());
            Console.Write("[{0},{1}]\n", squares[0, 0].getCenter().x, squares[0, 0].getCenter().y);
            Console.Write("{0}\n", squares[0, 0].getValid());
        }
    }
}
