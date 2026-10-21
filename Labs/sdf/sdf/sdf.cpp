

#include <iostream>
#include <fstream>
#include <string>

using namespace std;


int main(){
	ifstream file("name.txt");

	if (!file.is_open()) {
		return 1;
	}
	string name;
	if (file >> name) {
		cout << "Hello, " << name << endl;
	}
	file.close();
	return 0;
}
