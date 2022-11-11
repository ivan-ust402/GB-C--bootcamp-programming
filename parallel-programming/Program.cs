const int N = 1000; //размер матрицы
const int THREADS_NUMBER = 10; // десять потоков

// результат выполнения умножения матриц в однопотоке
int[,] serialMulRes = new int[N, N]; 

// результат выполнения умножения матриц в многопотоке (параллельного умножения матриц) 
int[,] threadMulRes = new int[N, N]; 

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);


SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix);
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes));

// Генерирование рандомным способом матрицы 1000 на 1000
int[,] MatrixGenerator(int rows, int columns) 
{
    Random _rand = new Random();
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

// Метод перемножения двух матриц в одном потоке
void SerialMatrixMul(int[,] a, int[,] b) {
    if(a.GetLength(1) != b.GetLength(0)) throw new System.Exception("Нельзя умножить такие матрицы");

    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }        
    }
}

// Метод параллельного перемножения матриц 
void PrepareParallelMatrixMul(int[,] a, int[,] b) {
    if(a.GetLength(1) != b.GetLength(0)) throw new System.Exception("Нельзя умножить такие матрицы");
    // переменная для определения сколько вычислений будет в каждом потоке
    int eachThreadCalc = N / THREADS_NUMBER;
    // Коллекция для хранения потоков
    var threadsList = new List<Thread>();
    for (int i = 0; i < THREADS_NUMBER; i++)
    {   
        // Задаем начало диапазона и конец для каждого потока
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        // Если последний поток
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsList.Add(new Thread(() => ParallelMatrixMul(a, b, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }
}

// Метод для подсчета каждого потока
void ParallelMatrixMul(int[,] a, int[,] b, int startPos, int endPos) {

    for (int i = startPos; i < endPos; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                threadMulRes[i, j] += a[i, k] * b[k, j];
            }
        }        
    }
}

// Сравнение двух матриц
bool EqualityMatrix(int[,] fmatrix, int[,] smatrix)
{
    bool res = true;

    for (int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fmatrix.GetLength(1); j++)
        {
            res = res && (fmatrix[i, j] == smatrix[i, j]);
        }
    }
    return res;
}

/* Тесты в BenchMark
Метод                   Время           Память
TestSerialMul           9.872 s         4KB
TestParallelMulThread   1.820 s         3KB
TestParallelMulTask     1.706 s         3KB
*/