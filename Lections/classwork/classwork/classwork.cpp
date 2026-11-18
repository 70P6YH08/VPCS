#include <iostream>

using namespace std;

class Time {
private:
    int hours;
    int minutes;
    int seconds;

public:
    Time() {
        hours = 12;
        minutes = 0;
        seconds = 0;
    }

    Time(int h, int m, int s) {
        hours = (h < 0) ? 0 : h;
        minutes = (m < 0 || m > 59) ? 0 : m;
        seconds = (s < 0 || s > 59) ? 0 : s;
    }

    Time(int totalSeconds) {
        if (totalSeconds < 0) {
            hours = minutes = seconds = 0;
        }
        else {
            hours = totalSeconds / 3600;
            minutes = (totalSeconds % 3600) / 60;
            seconds = (totalSeconds % 3600) % 60;
        }
    }

    void Print() {
        cout << (hours < 10 ? "0" : "") << hours << ":"
            << (minutes < 10 ? "0" : "") << minutes << ":"
            << (seconds < 10 ? "0" : "") << seconds << endl;
    }
};

int main() {
    Time t1;
    t1.Print();

    Time t2(14, 5, 9);
    t2.Print();

    Time t3(12108);
    t3.Print();

    return 0;
}
