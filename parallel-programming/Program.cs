const int N = 1000; //размер матрицы

// результат выполнения умножения матриц в однопотоке
int[,] serialMulRes = new int[N, N]; 

// результат выполнения умножения матриц в многопотоке (параллельного умножения матриц) 
int[,] threadMulRes = new int[N, N]; 

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

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