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
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}
int MinSumRow(int[,] array)
{
    int[][] splitedArray = new int[array.GetLength(0)][];
    int[] sumRows = new int[array.GetLength(0)];
    int min = 0;
    int minIndex = 0;

    for (int i = 0; i < array.GetLength(0); i++)
        splitedArray[i] = new int[array.GetLength(1)];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            splitedArray[i][j] = array[i, j];
        }
        sumRows[i] = splitedArray[i].Sum();
    }
    min = sumRows[0];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (min < sumRows[i])
        {
          min = sumRows[i];
          minIndex=i;
        }
    }
    return minIndex+1;
}

Console.WriteLine("Введите высоту и ширину массива через пробел:");
int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
Console.WriteLine("Введите диапазон генерирования элементов массива через пробел:");
int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

int[,] array = GenerateArray(size[0], size[1], range[0], range[1]);
PrintArray(array);
Console.WriteLine("Строка с минимальной суммой элементов: "+MinSumRow(array));



