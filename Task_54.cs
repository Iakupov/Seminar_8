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
int[,] SortArray(int[,] array)
{
    int[][] splitedArray = new int[array.GetLength(0)][];
    for (int i = 0; i < array.GetLength(0); i++)
        splitedArray[i] = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            splitedArray[i][j] = array[i, j];
        }
        Array.Sort(splitedArray[i]);
        Array.Reverse(splitedArray[i]);
    }

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            array[i, j] = splitedArray[i][j];
        }
    }
    return array;
}

Console.WriteLine("Введите высоту и ширину массива через пробел:");
int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
Console.WriteLine("Введите диапазон генерирования элементов массива через пробел:");
int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();

int[,] array = GenerateArray(size[0], size[1], range[0], range[1]);
PrintArray(array);
SortArray(array);
Console.WriteLine("Отсортированный массив:");
PrintArray(array);



