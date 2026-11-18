#include <iostream>
#include <string>
#include <stdexcept>
using namespace std;

class Animal {
private:
    string name;
    int age;
    string habitat;

public:
    Animal() {
        name = "Неизвестное животнное";
        age = 0;
        habitat = "Неизвестно";
    }
    Animal(string n, int a, string h) {
        name = n;
        setAge(a);
        habitat = h;
    }
    void info() const {
        cout << "Название: " << name << "Возраст: " << age << " лет, ареал обитания: " << habitat << endl;
    }

    string getName() const { return name; }
    void setName(string n) { name = n; }

    int getAge() const { return age; }
    void setAge(int a) {

    }
};

int main()
{
    \n";
}

