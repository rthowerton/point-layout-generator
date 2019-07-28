#include <iostream>
#include "squares.hpp"

using namespace std;

int main(){
	// Create a 2d Array of pointers to squares
	Square*** squares = new Square**[DIA];
	for(int i = 0; i < DIA/2; i++){
		squares[i] = new Square*[DIA/2];
	}
	
	// Populate the array with squares
	int x = 0, y;
	for(int i = -150; i < 150; i+=2){
		y = 0;
		for(int j = -150; j < 150; j+=2){
			Point bl = {i, j}; // Start building from the bottom left
			Point br = {i+2, j}; // Bottom right
			Point tl = {i, j+2}; // Top left
			Point tr = {i+2, j+2}; // Top right
			Point center = {i+1, j+1}; // center
			Square* s = new Square(tl, tr, bl, br, center); // Create a new pointer to a square
			s->isValid(); // Determine whether square is within the radius
			squares[x][y] = s; // Fill the array
			//cout << "[" << squares[x][y]->getCenter().x << "," << squares[x][y]->getCenter().y << "]" << endl;
			y++;
		}
		x++;
	}
	
	/* Proof of Concept */
	cout << "[" << squares[x/2][y/2]->getCenter().x << "," << squares[x/2][y/2]->getCenter().y << "]" << endl; // should be [1,1]
	cout << squares[x/2][y/2]->getValid() << endl; // should be 1

	cout << "[" << squares[x-1][y-1]->getCenter().x << "," << squares[x-1][y-1]->getCenter().y << "]" << endl; // Top right out of range
	cout << squares[x-1][y-1]->getValid() << endl; // should be 0
	
	cout << "[" << squares[0][0]->getCenter().x << "," << squares[0][0]->getCenter().y << "]" << endl; // should be [-149][-149]
	cout << squares[0][0]->getValid() << endl; // should be 0

	cout << "[" << squares[0][y-1]->getCenter().x << "," << squares[0][y-1]->getCenter().y << "]" << endl; // should be [-149,149]
	cout << squares[0][y-1]->getValid() << endl; // should be 0

	cout << "[" << squares[x-1][0]->getCenter().x << "," << squares[x-1][0]->getCenter().y << "]" << endl; // should be [149,-149]
	cout << squares[x-1][0]->getValid() << endl; // should be 0
	// TODO take in user input, algorithm for evenly spacing points, GUI.
	return 0;
}
