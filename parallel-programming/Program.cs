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

// Метод перемножения двух матриц
void SerialMatrixMul(int[,] a, int[,] b) {
    if(a.GetLength(1) != b.GetLength(0)) throw new System.Exception("Нельзя умножить такие матрицы");

    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes(i, j) += a[i, k] * b[k, j];
            }
        }        
    }
}