#include <math.h>

#define DIA 300

// An xy coordinate for points on a grid
struct Point{
	int x, y;
};

class Square{
	private:
		// A square is defined by 5 points:
		// Top left, top right, bottom left,
		// bottom right, and center.
		Point tl, tr, bl, br;
		Point center;
		bool valid;
	
	public:
		// Generic constructor
		Square(){}

		// Construct a square based on 5 points
		Square(Point a, Point b, Point c, Point d, Point e){
			tl = a;
			tr = b;
			bl = c;
			br = d;
			center = e;
			valid = true;
		}
		
		void setCenter(Point c){
			center = c;
		}

		void setTopLeft(Point c){
			tl = c;
		}
		
		void setTopRight(Point c){
			tr = c;
		}
		
		void setBotLeft(Point c){
			bl = c;
		}
		
		void setBotRight(Point c){
			br = c;
		}

		Point getCenter(){
			return center;
		}

		Point* getCorners(){
			Point* corners = new Point[4];
			corners[0] = tl;
			corners[1] = tr;
			corners[2] = bl;
			corners[3] = br;
			return corners;
		}
		
		// Check to see if a square is wholly within the 150mm radius
		void isValid(){
			// Sides of the triangle whose hypoteneuse is 150mm from [0,0]
			int a, b;
			// Determine which quadrant the square is in
			// and account for negative values
			if(center.x > 0 && center.y > 0){
				a = tr.y;
				b = tr.x;
			}
			else if(center.x < 0 && center.y > 0){
				a = tl.y;
				b = tr.x * -1;
			}
			else if(center.x < 0 && center.y < 0){
				a = bl.y * -1;
				b = bl.x * -1;
			}
			else if(center.x > 0 && center.y < 0){
				a = br.y * -1;
				b = br.x;
			}

			// Perform the check
			if((a*a)+(b*b) > (150*150))
				valid = false;
			else
				valid = true;
		}

		bool getValid(){
			return valid;
		}
};
