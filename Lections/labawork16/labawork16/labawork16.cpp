#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;


void bubble(vector<int>& a) {
    int n = a.size();

    for (int i = 0; i < n - 1; ++i) {
        bool swapped = false;

        for (int j = 0; j < n - i - 1; ++j) {
            if (a[j] > a[j + 1]) {
                swap(a[j], a[j + 1]);
                swapped = true;
            }

            cout << "Сравнение позиций " << j << " и " << j + 1 << ": ";
            for (int x : a) cout << x << ' ';
            cout << '\n';
        }

        if (!swapped) break;
    }
}

void selectionSort(vector<int>& a) {
    int n = a.size();

    for (int i = 0; i < n - 1; ++i) {
        int minIndex = i;

        for (int j = i + 1; j < n; ++j) {
            if (a[j] < a[minIndex]) {
                minIndex = j;
            }
        }

        swap(a[i], a[minIndex]);

        cout << "Итерация " << i + 1 << ", выбран минимум " << a[i] << ": ";
        for (int x : a) cout << x << ' ';
        cout << '\n';
    }
}

void printArray(const vector<int>& a) {
    for (int x : a) cout << x << ' ';
    cout << '\n';
}

int main() {
    setlocale(LC_ALL, "Russian");
    int n;
    cout << "Введите количество элементов: ";
    cin >> n;

    if (n <= 0) {
        cout << "Количество элементов должно быть положительным.\n";
        return 1;
    }

    vector<int> original(n);
    cout << "Введите элементы массива: ";
    for (int& x : original) cin >> x;

    vector<int> a = original;
    cout << "\nСортировка пузырьком:\n";
    bubble(a);
    cout << "Результат: ";
    printArray(a);

    a = original;
    cout << "\nСортировка выбором:\n";
    selectionSort(a);
    cout << "Результат: ";
    printArray(a);

    a = original;
    sort(a.begin(), a.end());
    cout << "\nСортировка функцией sort по возрастанию:\n";
    printArray(a);

    sort(a.begin(), a.end(), greater<int>());
    cout << "Сортировка функцией sort по убыванию:\n";
    printArray(a);

    return 0;
}