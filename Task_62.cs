int[,] CreateArray(int rows, int columns)
{
    int number = 1;
    int i = 0;
    int j = 0;
    int[,] array = new int[rows, columns];
leftToRight:

    while (j < array.GetLength(1))
    {
        array[i, j] = number;
        number += 1;
        j++;

        if (j == array.GetLength(1) - 1)
        {
            goto upToDown;
        }
        else if (array[i, j + 1] > 0 && array[i + 1, j - 1] > 0) goto end;
        else if (array[i, j + 1] > 0 && array[i + 1, j - 1] == 0)
        {
            goto upToDown;
        }
    }
upToDown:
    while (i < array.GetLength(0))
    {
        array[i, j] = number;
        number += 1;
        i++;
        if (i == array.GetLength(0) - 1) goto rightToLeft;
        else if (array[i + 1, j] > 0 && array[i, j - 1] > 0) goto end;
        else if (array[i + 1, j] > 0 && array[i, j - 1] == 0)
        {
            goto rightToLeft;
        }

    }
rightToLeft:
    while (j < array.GetLength(1))
    {
        array[i, j] = number;
        number += 1;
        j--;
        if (j == 0) goto downToUp;
        else if (array[i, j - 1] > 0 && array[i - 1, j] > 0) goto end;
        else if (array[i, j - 1] > 0 && array[i - 1, j] == 0)
        {
            goto downToUp;
        }
    }
downToUp:
    while (i < array.GetLength(0))
    {
        array[i, j] = number;
        number += 1;
        i--;
        if (i == 0 && array[i, j] == 0) goto leftToRight;
        else if (array[i - 1, j] > 0 && array[i , j + 1] > 0) goto end;
        else if (array[i - 1, j] > 0 && array[i , j + 1] == 0)
        {
            goto leftToRight;
        }
    }
end:
    array[i, j] = number;
    return array;
}
void PrintArray(int[,] array)
{
    for (int m = 0; m < array.GetLength(0); m++)
    {
        for (int n = 0; n < array.GetLength(1); n++)
        {
            if (array[m, n] < 10) Console.Write($"0{array[m, n]} ");
            else Console.Write($"{array[m, n]} ");
        }
        Console.WriteLine();
    }
}
Console.WriteLine("Введите высоту и ширину массива через пробел:");
int[] size = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
int[,] array = CreateArray(size[0], size[1]);
Console.WriteLine("Спиральный массив:");
PrintArray(array);
