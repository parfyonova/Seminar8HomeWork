/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по 
убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2 */

Console.WriteLine("Задача 54");
Console.WriteLine();
Console.Write("Введите кол-во строк: ");
int rows54 = int.Parse(Console.ReadLine()!);
Console.Write("Введите кол-во столбцов: ");
int columns54 = int.Parse(Console.ReadLine()!);
Console.WriteLine();
int[,] array54 = GetArray(rows54, columns54, 0, 10);
Console.WriteLine("Изначальный массив: ");
PrintArray(array54);
Console.WriteLine();
Console.WriteLine("Массив с упорядочными по убыванию элементами каждой строки: ");
ArrayReverseOrder(array54);
PrintArray(array54);
Console.WriteLine();

void ArrayReverseOrder(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int z = 0; z < array.GetLength(1) - 1; z++)
            {
                if (array[i, z] < array[i, z + 1])
                {
                    int temp = array[i, z + 1];
                    array[i, z + 1] = array[i, z];
                    array[i, z] = temp;
                }
            }
        }
    }
}

/* Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, 
которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и выдаёт номер строки с 
наименьшей суммой элементов: 1 строка */

Console.WriteLine("Задача 56");
Console.WriteLine();
Console.Write("Введите кол-во строк: ");
int rows56 = int.Parse(Console.ReadLine()!);
Console.Write("Введите кол-во столбцов: ");
int columns56 = int.Parse(Console.ReadLine()!);
Console.WriteLine();
int[,] array56 = GetArray(rows56, columns56, 0, 10);
Console.WriteLine("Массив: ");
PrintArray(array56);
Console.WriteLine();
Console.WriteLine("Наименьшая сумма элементов в строке: ");
ArraySumRows(array56);
Console.WriteLine();

void ArraySumRows(int[,] array)
{
    int sum = 0; // sumRow
    int sumTemp = 0; // minRow
    int iTemp = 0; // minSumRow
    for (int i = 0; i < array.GetLength(1); i++)
    {
        sumTemp += array[0, i];
    }
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        if (sum < sumTemp)
        {
            sumTemp = sum;
            iTemp = i; // добавляем 1, чтобы был не индекс. а именно порядковый номер строки
        }
        sum = 0;
    }
    Console.Write(iTemp + 1);
}


/* Задача 58: Задайте две квадратные матрицы. Напишите программу, 
которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18 */

Console.WriteLine("Задача 58");
Console.WriteLine();
Console.Write("Введите кол-во строк/столбцов (они равны, т.к. матрицы квадратные) для каждой матрицы: ");
int rows58 = int.Parse(Console.ReadLine()!);
int columns58 = rows58;
Console.WriteLine();
int[,] array58First = GetArray(rows58, columns58, 0, 10);
Console.WriteLine("Первая матрица: ");
PrintArray(array58First);
Console.WriteLine();
int[,] array58Second = GetArray(rows58, columns58, 0, 10);
Console.WriteLine("Вторая матрица: ");
PrintArray(array58Second);
Console.WriteLine();
int[,] array58Result = new int[rows58,columns58];
Console.WriteLine("Результирующая матрица: ");

for (int i58 = 0; i58 < array58First.GetLength(0); i58++)
{
    for (int j58 = 0; j58 < array58Second.GetLength(1); j58++)
    {
        array58Result[i58, j58] = 0;
        for (int k58 = 0; k58 < array58First.GetLength(1); k58++)
        {
            array58Result[i58, j58] += array58First[i58, k58] * array58Second[k58, j58];
        }
    }
}
PrintArray(array58Result);
Console.WriteLine();

/* Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1) */

Console.WriteLine("Задача 60");
Console.WriteLine();
int arraySizeX = 2;
int arraySizeY = 2;
int arraySizeZ = 2;
int minNumber = 10;
int maxNumber = 99;
int[,,] array3d60 = new int[arraySizeX, arraySizeY, arraySizeZ];
FillArrayRandomNumber(array3d60, minNumber, maxNumber);
PrintArrayWithIdex(array3d60);

void FillArrayRandomNumber(int[,,] array, int minNumber = 0, int maxNumber = 9)
{
    Random rand = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int h = 0; h < array.GetLength(2); h++)
            {
                while (array[i, j, h] == 0)
                {
                    int number = rand.Next(minNumber, maxNumber + 1);

                    if (IsNumberInArray(array, number) == false)
                    {
                        array[i, j, h] = number;
                    }
                }

            }
        }
    }
}

bool IsNumberInArray(int[,,] array, int number)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int h = 0; h < array.GetLength(2); h++)
            {
                if (array[i, j, h] == number) return true;
            }
        }
    }

    return false;
}

void PrintArrayWithIdex(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int h = 0; h < array.GetLength(2); h++)
            {
                Console.Write(array[i, j, h]);
                Console.Write("({0},{1},{2})\t", i, j, h);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}

/* Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07 */

Console.WriteLine("Задача 62");
Console.WriteLine();
int n = 4;
int[,] array62 = new int[n, n];
int temp = 1;
int i = 0;
int j = 0;
while (temp <= array62.GetLength(0) * array62.GetLength(1))
{
    array62[i, j] = temp;
    temp++;
    if (i <= j + 1 && i + j < array62.GetLength(1) - 1)
        j++;
    else if (i < j && i + j >= array62.GetLength(0) - 1)
        i++;
    else if (i >= j && i + j > array62.GetLength(1) - 1)
        j--;
    else
        i--;
}
PrintArray62(array62);
Console.WriteLine();
void PrintArray62(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] / 10 <= 0)
                Console.Write($" {array[i, j]} ");
            else Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}


int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($"{Array[i, j]} ");
        }
        Console.WriteLine();
    }
}