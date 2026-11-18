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
    Animal() : name("Неизвестно"), age(0), habitat("Неизвестно") {}

    Animal(const string& name, int age, const string& habitat)
        : name(name), age(0), habitat(habitat) {
        setAge(age);
    }

    string getName() const { return name; }
    int getAge() const { return age; }
    string getHabitat() const { return habitat; }

    void setName(const string& newName) { name = newName; }

    void setAge(int newAge) {
        if (newAge < 0) {
            throw invalid_argument("Возраст не может быть отрицательным");
        }
        age = newAge;
    }

    void setHabitat(const string& newHabitat) {
        habitat = newHabitat;
    }

    void info() const {
        cout << "Имя: " << name
            << ", возраст: " << age
            << ", ареал обитания: " << habitat << '\n';
    }
};

int main() {
    setlocale(LC_ALL, "Russian");
    try {
        Animal animal1;
        Animal animal2("Тигр", 5, "Тайга");
        Animal animal3("Котик", 6, "Дом");
        Animal animal4("Заяц", 2, "Пустыня");

        cout << "Созданные животные:\n";
        animal1.info();
        animal2.info();
        animal3.info();
        animal4.info();

        animal2.setAge(6);
        cout << "\nНовый возраст " << animal2.getName()
            << ": " << animal2.getAge() << '\n';
    }
    catch (const invalid_argument& error) {
        cerr << "Ошибка: " << error.what() << '\n';
    }

    return 0;
}