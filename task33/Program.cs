// Заполнить матрицу A размерности n*m случайными числами. Переписать в массив B элементы aii первой главной диагонали матрицы A,
// в массив C — элементы  другой главной диагонали матрицы A. Полученные массивы вывести на экран в виде таблицы из трех колонок.

int message(string text)
{
    Console.WriteLine(text);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,] getMatrix(int rows, int columns) 
{
    int[,] arr = new int[rows,columns];
    Random rnd = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i,j] = rnd.Next(1,10);
        }
    }
    return arr;
}

void printMatrix(int[,] arr) 
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write(arr[i,j] + " ");
        }
        Console.WriteLine();
    }
}

int[] getArray(int[,] arr)
{
    int[] myArr = new int[arr.GetLength(0) * arr.GetLength(1)];
    int count = 0;

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            myArr[count] = arr[i,j];
            count++;
        }
    }
    return myArr;
}


int[] getMainDiag(int[,] arr)
{
    int size = 0;
    if (arr.GetLength(0) > arr.GetLength(1))
    {
        size = arr.GetLength(1);
    }
    else
    {
        size = arr.GetLength(0);
    }
    int[] myArr = new int[size];
    int count = 0;

    for (int i = 0; i < size; i++)
    {
        for (int j = i; j <= i; j++)
        {
            myArr[count] = arr[i,j];
            count++;
        }
    }
    return myArr;
}

int[] getSecondMainDiag(int[,] arr)
{
    int size = 0;
    if (arr.GetLength(0) > arr.GetLength(1))
    {
        size = arr.GetLength(1);
    }
    else
    {
        size = arr.GetLength(0);
    }
    int[] myArr = new int[size];
    int count = 0;

    for (int i = 0; i < size; i++)
    {
        for (int j = arr.GetLength(1) - i; j <= arr.GetLength(1) - i; j++)
        {
            myArr[count] = arr[i,j - 1];
            count++;
        }
    }
    return myArr;
}
int rows = message("Введите количество строк матрицы");
int columns = message("Введите количество столбцов матрицы");
int[,] matrix = getMatrix(rows,columns);
printMatrix(matrix);
Console.WriteLine();
Console.WriteLine();
int[] mainDiag = getMainDiag(matrix);
int[] secondDiag = getSecondMainDiag(matrix);


int count_column_a = 0, count_rows_b = 0, out_counter = 0;
for (int count_row = 0; count_row < (columns * rows); count_row++)
{
    Console.Write("{0,4}   ", matrix[count_rows_b,count_column_a]);
    count_column_a++;
    if (count_column_a == columns)
    {
        count_column_a = 0;
        count_rows_b++;
    }
    if (out_counter <= (rows - 1) && out_counter != columns)
    {
        Console.Write("{0} {1,4} ", mainDiag[count_row], secondDiag[count_row]);
        out_counter++;
    }
    Console.WriteLine();
}
