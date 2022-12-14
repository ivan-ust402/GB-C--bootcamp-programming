/* int[] array = new int[5];
for (int i = 0; i < 5; i++) {
    array[i] = Convert.ToInt32(Console.ReadLine());
}
Console.WriteLine("[" + string.Join(" ", array) + "]"); */

// Задача 1. Сколько по времени будет работать программа, если нам нужно найти определенный элемент?
// Console.WriteLine(array[3]); //O(1)

// Сложность алгоритма O() (O нотация) - это количество действий, чтобы получить конечный результат

// Задача 2. Сформировать массив [4, 5, 3, 1, 2]. Узнать сумму элементов этого массива. Сколько операций? В данном случае O(5) -> в общем случае O(n)
// Если оптимизировать, то мы можем для начала отсортировать массив
// [1, 2, 3, 4, 5] - O(n*log(n))
// Выявили, что это последовательность, тогда мы можем воспользоваться формулой для подсчета суммы последовательности: ((5+1)/2)*5, тогда O(1)
// Весь алгоритм поменяет время работы от О(n) до O(n*log(n)) + O(1).
// Мы сократили время работы алгоритма.
// Но есть подвох. Не всегда O(n*log(n)) + O(1) приведут к более быстрому результату  n < n*log(n) + 1
// В данном случае наиболее оптимально просто пройтись по всем элементам массива

// Пример алгоритма O(n^2): сортировка выбором, сортировка пузырьком
// Задача 3. Рассмотрим задачу с выводом таблицы умножения

/* int n = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    for (int j = 1; j < n; j++)
    {
        Console.Write(i * j);
        Console.Write("\t");
    }
    Console.WriteLine();
} */

// Как сократить время работы программы?
// Убрать повторы. Раделим матрицу по диагонали и заполним одну, а затем отзеркалим
int m = Convert.ToInt32(Console.ReadLine());
int[,] matrix = new int[m, m];
/*  Заполнение будет происходить следующим образом
        1 2 3 4 5
        2 - - - -
        3 | - - -
        4 | | - -
        4 | | | -
*/
for (int i = 0; i < m; i++)
{   
    for (int j = i; j < m; j++)
    {
            matrix[i, j] = (i + 1) * (j + 1);
            matrix[j, i] = (i + 1) * (j + 1);
    }
    Console.WriteLine();
}

for (int i = 0; i < m ; i++)
{
    for (int j = 0; j < m ; j++)
    {
        Console.Write(matrix[i, j]);
        Console.Write(" ");
    }
    Console.WriteLine(" ");
}

// Время выполнения O(n^2 / 2)
// Если добавить третий вложенный цикл, то время будет O(n^3 / 3)
// Применение алгоритмов в работе с огромными потоками данных, приводит к оптимизации и увеличению производительности 
