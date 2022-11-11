// Гонка алгоритмов сортировки
// Сколько потратили памяти
// Сколько времени на это ушло


// Quick Sort
int[] QuickSort(int[] arr, int minIndex, int maxIndex) {
    if (minIndex >= maxIndex) return arr;
    int pivot = GetPivotIndex(arr, minIndex, maxIndex);
    QuickSort(arr, minIndex, pivot - 1);
    QuickSort(arr, pivot + 1, maxIndex);
    return arr;
}

int GetPivotIndex(int[] arr, int minIndex, int maxIndex) {
    int pivotIndex = minIndex - 1;
    for (int i = minIndex; i <= maxIndex; i++)
    {
        if (arr[i] < arr[maxIndex]) {
            pivotIndex++;
            Swap(arr, i, pivotIndex);
        }
    }
    pivotIndex++; 
    Swap(arr, pivotIndex, maxIndex); 
    return pivotIndex;
}

void Swap(int[] array, int leftValue, int rightValue) {
    int temp = array[leftValue];
    array[leftValue] = array[rightValue];
    array[rightValue] = temp;
}

// bubble sort
int [] BubbleSort(int[] array) {
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length - 1; j++)
        {
            if (array[j] > array[j + 1]) {
                int temp = array[j];
                array[j] = array[j+1];
                array[j + 1] = temp;
            }
        }
    }
    return array;
} 

// Selection sort
int[] SelectionSort(int[] array) {
    for (int i = 0; i < array.Length - 1; i++)
    {
        int min_index = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[min_index]) {
                min_index = j;
            }
        }
        int temp = array[min_index];
        array[min_index] = array[i];
        array[i] = temp;
    }
    return array;
}

// Counting Sort
int[] CountingSort(int[] array) {
    int min = array[0];
    int max = array[0];
    foreach (int element in array) {
        if (element > max) {
            max = element;
        }
        else if (element < min) {
            min = element;
        }

        // поправка
        int correctionFactor = min != 0 ? -min : 0;
        max += correctionFactor;

        int[] count = new int[max + 1];
        for (int i = 0; i < array.Length; i++)
        {
            count[array[i] + correctionFactor]++;
        }
        int index = 0;
        for (int i = 0; i < count.Length; i++)
        {
            for (int j = 0; j < count[i]; j++)
            {
                array[index] = i - correctionFactor;
                index++;
            }
        }
    }
    return array;
}

// Shaker Sort
void ShakerSort(int[] listS) {
    int left = 0;
    int right = listS.Length - 1,
    count = 0;

    while (left < right) {
        for (int i = left; i < right; i++)
        {
            count++;
            if (listS[i] > listS[i + 1]) {
                Swap(listS, i, i + 1);
            }
        }
        right--;
        for (int i = right; i > left; i--)
        {
            count++;
            if (listS[i - 1] > listS[i]) {
                Swap(listS, i - 1, i);
            }
        }
        left++;
    }
}

// Массив на 1000 элементов, заполняется случайным образом
// Запускает препод все в benchmark
/* 
Результаты:
Метод:              Время               Рейтинг     Память         Кол. опер.
TestQuickSort       61.16 мкс O(n*logn)  1           4kb O(n)       9955 
TestBubbleSort      2010.46 мкс O(n^2)   5           4kb O(n)       1000000
TestSelectionSort   590.68 мкс O(n^2/4)  3           4kb O(n+1)     500000
TestCountingSort    345.97 мкс O(n+k)    2           394kb O(n+k)   2000
TestShakerSort      1483.48 мкс          4           4kb       
TestQuickDotnetSort более оптимизирована чем наш QuickSort

    k-количество уникальных элементов (1000)
 */