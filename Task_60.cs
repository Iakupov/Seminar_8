int[,,] GenerateArray(int Lngth, int Wdth, int Depth, int min, int max)
{
    int[,,] array = new int[Lngth, Wdth, Depth];
    int[] numbers = new int[100];
    int tempA = 0;
    int tempB = 0;
    for (int i = 0; i < 100; i++)
    {
        numbers[i] = i;
    }
    for (int i = 0; i < Lngth; i++)
    {
        for (int j = 0; j < Wdth; j++)
        {
            for (int z = 0; z < Depth; z++)
            {
                tempA = new Random().Next(min, max);
                if (numbers[tempA] == 0)
                {
                    tempB = tempA;
                    while (numbers[tempA] == 0 && tempA < 100)
                    {
                        tempA++;
                    }
                    if (numbers[tempA] == 0)
                    {
                        while (numbers[tempB] == 0 && tempB < 100)
                        {
                            tempB--;
                        }
                        array[i, j, z] = numbers[tempB];
                        numbers[tempB] = 0;
                    }
                    else
                    {
                        array[i, j, z] = numbers[tempA];
                        numbers[tempA] = 0;
                    }
                }
                else
                {
                    array[i, j, z] = numbers[tempA];
                    numbers[tempA] = 0;
                }
            }
        }
    }

    return array;
}
void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {

        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write("|");
            for (int z = 0; z < array.GetLength(2); z++)
            {
                Console.Write($"{array[i, j, z]}({i},{j},{z})");
            }
            Console.Write("|");
            Console.WriteLine();
        }
    }
}


Console.WriteLine("Введите высоту, ширину и глубину  массива через пробел:");
int[] sizeA = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
int[,,] arrayA =new int[sizeA[0], sizeA[1], sizeA[2]];
if (sizeA[0]*sizeA[1]*sizeA[2]<=100)
arrayA = GenerateArray(sizeA[0], sizeA[1], sizeA[2], 10, 100);
else Console.WriteLine("Превышение по размеру");
PrintArray(arrayA);


