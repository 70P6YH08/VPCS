#define _CRT_SECURE_NO_WARNINGS
#include <cstdio>
#include <clocale>
#include <stack>

using namespace std;

void fillStack(stack<int>& st) {
    int n, value;
    printf("Введите количество элементов N: ");
    scanf("%d", &n);

    for (int i = 0; i < n; i++) {
        printf("Введите элемент [%d]: ", i + 1);
        scanf("%d", &value);
        st.push(value);
    }
}

void printNElements(stack<int> st, int n) {
    printf("Первые %d элементов с вершины стека: ", n);
    int printed = 0;
    while (!st.empty() && printed < n) {
        printf("%d ", st.top());
        st.pop();
        printed++;
    }
    printf("\n");
} 

void printAllElements(stack<int> st) {
    if (st.empty()) {
        printf("Стек пуст.\n");
        return;
    }

    printf("Все элементы стека: ");
    while (!st.empty()) {
        printf("%d ", st.top());
        st.pop();
    }
    printf("\n");
}

double sr(stack<int> st) {
    if (st.empty()) {
        return 0.0;
    }

    long long sum = 0;
    int count = 0;

    while (!st.empty()) {
        sum += st.top();
        st.pop();
        count++;
    }

    return (double)sum / count;
}

int main() {
    setlocale(LC_ALL, "Russian");

    stack<int> myStack;

    fillStack(myStack);

    int k;
    printf("\nСколько элементов стека вывести на экран? ");
    scanf("%d", &k);
    printNElements(myStack, k);

    printAllElements(myStack);

    double a = sr(myStack);
    printf("Среднее арифметическое всех элементов стека: %.2f\n", a);

    return 0;
}