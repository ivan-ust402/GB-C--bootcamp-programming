﻿// Не часто используется, сложность O(n^2)
/* Объяснение:
1. входной массив [3, 1, 5, 0, 7, 9, 8]
2. начинаем прохождение по массиву
    Мое видение:
    1. Берем первый элемент и последующий за ним и сравниваем их между собой (работаем парами и переставляем в парах элементы)
    3 < 1 ? нет
    [1, 3, 5, 0, 7, 9, 8]
    3 < 5 ? да
    [1, 3, 5, 0, 7, 9, 8]
    5 < 0 ? нет
    [1, 3, 0, 5, 7, 9, 8]
    5 < 7 ? да
    [1, 3, 0, 5, 7, 9, 8]
    7 < 9 ? да
    [1, 3, 0, 5, 7, 9, 8]
    9 < 8 ? нет
    [1, 3, 0, 5, 7, 8, 9]
    2. Промежуточный массив: [1, 3, 0, 5, 7, 8, 9] -> Снова проходимся по массиву
    1 < 3 ? да
    [1, 3, 0, 5, 7, 8, 9]
    3 < 0 ? нет
    [1, 0, 3, 5, 7, 8, 9]
    3 < 5 ? да
    [1, 0, 3, 5, 7, 8, 9]
    5 < 7 ? да
    [1, 0, 3, 5, 7, 8, 9]
    7 < 8 ? да
    [1, 0, 3, 5, 7, 8, 9]
    8 < 9 ? да
    [1, 0, 3, 5, 7, 8, 9]
    3. Промежуточный массив: [1, 0, 3, 5, 7, 8, 9] -> Снова проходимся по массиву
    1 < 0 ? нет
    [0, 1, 3, 5, 7, 8, 9]
    3 < 0 ? нет
    [0, 1, 3, 5, 7, 8, 9]
    3 < 5 ? да
    [0, 1, 3, 5, 7, 8, 9]
    5 < 7 ? да
    [0, 1, 3, 5, 7, 8, 9]
    7 < 8 ? да
    [0, 1, 3, 5, 7, 8, 9]
    8 < 9 ? да
    [0, 1, 3, 5, 7, 8, 9]

Изложение как в лекции:

    1. Берем первый элемент и последующий за ним и сравниваем их между собой (работаем парами и переставляем в парах элементы)
    3 < 1 ? нет
    [1, 3, 5, 0, 7, 9, 8]

    2. После перстановки снова идем сначала
    1 < 3 ? да 
    [1, 3, 5, 0, 7, 9, 8]
    3 < 5 да
    [1, 3, 5, 0, 7, 9, 8]
    5 < 0 нет
    [1, 3, 0, 5, 7, 9, 8]

    3. После перстановки снова идем сначала
    1 < 3 ? да 
    [1, 3, 0, 5, 7, 9, 8]
    3 < 0 нет
    [1, 0, 3, 5, 7, 9, 8]

    4. После перстановки снова идем сначала
    1 < 0 нет
    [0, 1, 3, 5, 7, 9, 8]    

    5. После перстановки снова идем сначала
    0 < 1 да 
    1 < 3 да
    3 < 5 да
    5 < 7 да
    7 < 9 да
    9 < 8 нет
    [0, 1, 3, 5, 7, 8, 9] 

    5. После перстановки снова идем сначала
    0 < 1 да 
    1 < 3 да
    3 < 5 да
    5 < 7 да
    7 < 8 да
    8 < 9 да
    Итоговый массив -> [0, 1, 3, 5, 7, 8, 9]

    6. 7.  Будем проходиться по массиву столько раз сколько в массиве элементов

*/ 
Console.WriteLine("Введите количество элементов массива: ");
int n = Convert.ToInt32(Console.ReadLine());
// Заполнение массива
int[] array = new int[n];
for (int i =0; i < n; i++) {
    Console.Write("Введите число: ");
    array[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine();
Console.WriteLine("Начальный массив: [" + string.Join(", ", array) + "]");
Console.WriteLine();
// Сортировка пузырьком - попарно переставляем все элементы за один проход, если делать метод как в описании, то нужно выходить из внутреннего цикла с j каждый раз
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n - 1; j++)
    {
        if (array[j] > array[j + 1]) {
            int temp = array[j];
            array[j] = array[j+1];
            array[j + 1] = temp;
        }
    }
    Console.WriteLine(i + ". Промежуточный массив: [" + string.Join(", ", array) + "]");
}
Console.WriteLine();
Console.WriteLine("Конечный массив: [" + string.Join(", ", array) + "]");


