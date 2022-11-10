// Быстрая сортировка
/* 
    один из самых быстрых алгоритмов, используется в dotnet. В общем случае O(n*logn)
                          0  1   2  3  4  5  6
    Входной массив arr = [1, 0, -6, 2, 5, 3, 2]
    Отсортировать по возврастанию.
    Суть сортировки:
    1. Выбор опорного элемента pivot(либо первый элемент, либо последний)
        Берем самый правый элемент и считаем его опорным
        pivot = arr[6] = 2
        Задача, чтобы все элементы меньше опорного стояли слева от опорного, а те, что больше - справа
        перемещаем pivot согласно условию
        [1, 0, -6, 2, 2(pivot), 5, 3]
    2. Берем левый подмассив и правый подмасив и делаем то же самое, что мы делали с исходным массивом:
     1. Работа с левым подмассивом:
        1. Левый подмассив [1, 0, -6, 2]
        pivot = arr[3] = 2
        [1, 0, -6, 2(pivot)]
        2. Левый подмассив [1, 0, -6]
        pivot = -6 -> [-6(pivot), 1, 0, ] -> [1, 0]
        3. Остался только правый подмассив [1, 0]
        pivot = 0 -> [0(pivot), 1] 
        4. Результат левого подмассива -> [-6, 0, 1, 2]
     2. Работа с правым подмассивом:
        1. Правый подмассив [5, 3]
        pivot = 3
        [3(pivot), 5]
        2. Результат левого подмассива -> [3, 5]
    3. Результат: [-6, 0, 1, 2, 2, 3, 5]

    Общий алгоритм данной сортировки:
    1. arr = [1, 0, -6, 2, 5, 3, 2]
    2. pivot = arr[6] = 2
    3. Вызвать шаги 1-2 для подмассива слева от pivot и справа от pivot
*/

// Console.WriteLine("Введите количество элементов массива: ");
// int n = Convert.ToInt32(Console.ReadLine());
// Заполнение массива
// int[] array = new int[n];
// for (int i = 0; i < n; i++) {
//     Console.Write("Введите число: ");
//     array[i] = Convert.ToInt32(Console.ReadLine());
// }
// Console.WriteLine();
int[] array = {1, 0, -6, 2, 5, 3, 2};
Console.WriteLine("Начальный массив: [" + string.Join(", ", array) + "]");
int[] res = QuickSort(array, 0, array.Length - 1);
Console.WriteLine("Конечный массив: [" + string.Join(", ", res) + "]");

int[] QuickSort(int[] arr, int minIndex, int maxIndex) {
    if (minIndex >= maxIndex) return arr;
    int pivot = GetPivotIndex(arr, minIndex, maxIndex);
    QuickSort(arr, minIndex, pivot - 1);
    QuickSort(arr, pivot + 1, maxIndex);
    return arr;
}

int GetPivotIndex(int[] arr, int minIndex, int maxIndex) {
    // Задаем начальный дефолтный pivot за пределами индексации массива
    int pivotIndex = minIndex - 1;
    for (int i = minIndex; i <= maxIndex; i++)
    {
        if (arr[i] < arr[maxIndex]) {
            pivotIndex++;
            Swap(arr, i, pivotIndex);
        }
        /* 
        [1, 0, -6, 2, 5, 3, 2] pivotIndex = -1
        1. [1, 0, -6, 2, 5, 3, 2] pivotIndex = 0
        2. [1, 0, -6, 2, 5, 3, 2] pivotIndex = 1
        3. [1, 0, -6, 2, 5, 3, 2] pivotIndex = 2
        4. [1, 0, -6, 2, 5, 3, 2] pivotIndex = 2
        5. [1, 0, -6, 2, 5, 3, 2] pivotIndex = 2
        6. [1, 0, -6, 2, 5, 3, 2] pivotIndex = 2
        7. [1, 0, -6, 2, 5, 3, 2] pivotIndex = 2   
        */
    }
    pivotIndex++; //=3
    Swap(arr, pivotIndex, maxIndex); //[1, 0, -6, 2(pivot), 5, 3, 2]
    return pivotIndex;
}

void Swap(int[] array, int leftValue, int rightValue) {
    int temp = array[leftValue];
    array[leftValue] = array[rightValue];
    array[rightValue] = temp;
}


