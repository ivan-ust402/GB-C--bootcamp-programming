// Сортировка подсчетом
// Сортировка как и выбором, так и пузырьковая основаны на сравнении элементов
// Работает достаточно быстро
// Работает только с цифрами

/* 
[0, 2, 3, 2, 1, 5, 9, 1, 1] нужно отсортировать по возрастанию

для корректной работы нужно создать новый массив
[0, 0, 0, 0, 0, 0, 0, 0, 0, 0]
 0  1  2  3  4  5  6  7  8  9
считаем сколько нолей в массиве
0 -> 1
ставим прописываем количество в 0 индекс
[1, 0, 0, 0, 0, 0, 0, 0, 0, 0]
сколько единиц
[1, 3, 0, 0, 0, 0, 0, 0, 0, 0]
сколько 2
[1, 3, 2, 0, 0, 0, 0, 0, 0, 0]
сколько троек
[1, 3, 2, 1, 0, 0, 0, 0, 0, 0]
сколько четверок -> 0
[1, 3, 2, 1, 0, 0, 0, 0, 0, 0]
сколько пятерок
[1, 3, 2, 1, 0, 1, 0, 0, 0, 0]
сколько шестерок -> 0
сколько семерок -> 0
сколько восьмерок -> 0
сколько девяток
[1, 3, 2, 1, 0, 1, 0, 0, 0, 1]

Теперь наша задача вставить в наш отсортированный массив по порядку нужное количество элементов
0 - один, прописываем в 0 индекс
[0,
1 -> 3 от 1 до 3 включительно индекса заполняем единицами
[0, 1, 1, 1
Заполняем по этому же алгоритму остальные элементы
2 -> 2 
[0, 1, 1, 1, 2, 2
3 -> 1 
[0, 1, 1, 1, 2, 2, 3
4 -> 0 
[0, 1, 1, 1, 2, 2, 3
5 -> 1 
[0, 1, 1, 1, 2, 2, 3, 5
6 -> 0 
[0, 1, 1, 1, 2, 2, 3, 5
7 -> 0 
[0, 1, 1, 1, 2, 2, 3, 5
8 -> 0 
[0, 1, 1, 1, 2, 2, 3, 5
9 -> 0 
[0, 1, 1, 1, 2, 2, 3, 5, 9]
Окончание сортировки
*/
int[] array = {0, 2, 3, 2, 1, 5, 9, 1, 1};
int[] array1 = {0, 2, 4, 10, 20, 5, 6, 1, 2};
int[] array2 = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1};
CountingSort(array);
CountingSortExtended(array1);
CountingSortUniversal(array2);

Console.WriteLine("[" + string.Join(", ",array) + "]");
Console.WriteLine("[" + string.Join(", ",array1) + "]");
Console.WriteLine("[" + string.Join(", ",array2) + "]");

void CountingSort(int[] inputArray) {
    int[] counters = new int[10]; // массив повторений

    for (int i = 0; i < inputArray.Length; i++)
    {
        // counters[inputArray[i]]++;
        int ourNumber = inputArray[i];
        counters[ourNumber]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i;
            index++; 
        }
    }
} 

/* 
Новый случай, что если в массиве числа от нуля до неизвестно большого числа
[0, 2, 4, 10, 20, 5, 6, 1, 2]
диапазон массива теперь будет от 0 до 20
*/

// Генерация гитигнора dotnet new gitignore

void CountingSortExtended(int[] inputArray) {
    // Поиск максимального числа
    int max = inputArray.Max();
    // Поиск минимального числа
    // int min = inputArray.Min();
    int size = max + 1;
    int[] counters = new int[size];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i]]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i;
            index++; 
        }
    }
}

// Новый случай с отрицательными числами
// Загвоздка в том, что отрицательных индексов нет
// Нам нужно задать смещение
/* 
{-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1}

смещаем массив на 10, т.к. самое минимальное число -10

offset = -10 * -1
counters [max + offset + 1]

*/

void CountingSortUniversal(int[] inputArray) {
    // Поиск максимального числа
    int max = inputArray.Max();
    // Поиск минимального числа
    int min = inputArray.Min();
    int offset = 0;
    int size = max + 1;
    if (min < 0)
    {
        offset = -min;
        size = size + offset;
    } 

    int[] counters = new int[size];

    for (int i = 0; i < inputArray.Length; i++)
    {
        counters[inputArray[i] + offset]++;
    }

    int index = 0;
    for (int i = 0; i < counters.Length; i++)
    {
        for (int j = 0; j < counters[i]; j++)
        {
            inputArray[index] = i - offset;
            index++; 
        }
    }
}