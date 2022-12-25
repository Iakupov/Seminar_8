int[,] GenerateArray(int Lngth, int Wdth, int min, int max)
{
    int[,] array = new int[Lngth, Wdth];
    for (int i = 0; i < Lngth; i++)
    {
        for (int j = 0; j < Wdth; j++)
        {
            array[i, j] = new Random().Next(min, max);
        }
    }
    return array;
}
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("|");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.Write("|");
        Console.WriteLine();
    }
}
int[,] MatrixMultiplication(int[,] arrayA, int[,] arrayB)
{
    int[,] resultArray = new int[arrayA.GetLength(0), arrayA.GetLength(1)];
    for (int i = 0; i < arrayA.GetLength(0); i++)
    {
        for (int j = 0; j < arrayA.GetLength(1); j++)
        {
            for (int z = 0; z < arrayA.GetLength(0); z++)
            {
                resultArray[i, j] += arrayA[i, z] * arrayB[z, j];
            }
        }
    }
    return resultArray;
}

Console.WriteLine("Введите высоту и ширину первой матрицы через пробел:");
int[] sizeA = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
Console.WriteLine("Введите высоту и ширину второй матрицы через пробел:");
int[] sizeB = Console.ReadLine().Split().Select(int.Parse).ToArray();
if (sizeA[0] == sizeB[1] && sizeA[1] == sizeB[0])
{
    int[,] arrayA = GenerateArray(sizeA[0], sizeA[1], 1, 4);
    int[,] arrayB = GenerateArray(sizeA[0], sizeA[1], 1, 4);
    PrintArray(arrayA);
    Console.WriteLine("X");
    PrintArray(arrayB);
    Console.WriteLine("=");
    PrintArray(MatrixMultiplication(arrayA, arrayB));
}
else Console.WriteLine("ОШИБКА! Матрицы с данными размерами нельзя перемножить");


