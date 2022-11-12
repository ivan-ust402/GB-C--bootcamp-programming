﻿// Сортировка подсчетом
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