// **Задача**:
// Написать программу, которая из имеющегося массива строк формирует массив из строк,
// длина которых меньше либо равна 3 символа. Первоначальный массив можно ввести с клавиатуры,
// либо задать на старте выполнения алгоритма. При решении не рекомендуется пользоваться коллекциями,
// лучше обойтись исключительно массивами.
// **Примеры**:
// ["hello", "2", "world", ":-)"] -> ["2", ":-)"]
// ["1234", "1567", "-2", "computer science"] -> ["-2"]
// ["Russia", "Denmark", "Kazan"] -> []

Console.Clear();
PrintTitle("Блок № 1. Контрольная работа");

int sizeOfArray = InputNumber("Введите размер массива: ", 0);
string[] initialArray = new string[sizeOfArray];
FillArrayOfStrings(initialArray);

int maxLength = InputNumber("Какие строки будем отбирать? Введите макс. длину в символах: ", 0);
string[] finalArray;
SelectStringsFromArray(initialArray, out finalArray, maxLength);

Console.WriteLine("Исходный массив строк:");
PrintArray(initialArray);
Console.WriteLine("Массив строк заданной длины:");
PrintArray(finalArray);

//=================================================================================================================//

void PrintTitle(string message)
{
    string underline = new string('-', message.Length);
    Console.WriteLine($"{message}\n{underline}\n");
}

int InputNumber(string message, int typeOfNumber)
{
    Console.Write(message);
    string input = Console.ReadLine();
    int number = 0;
    switch (typeOfNumber)
    {
        case 0:
            while (!int.TryParse(input, out number) || number < 1)
            {
                Console.Write("Неверный ввод!\nВведите натуральное число: ");
                input = Console.ReadLine();
            }
            break;
        case 1:
            while (!int.TryParse(input, out number))
            {
                Console.Write("Неверный ввод!\nВведите целое число: ");
                input = Console.ReadLine();
            }
            break;
        case 2:
            while (!int.TryParse(input, out number) || number < 0)
            {
                Console.Write("Неверный ввод!\nВведите целое неотрицательное число: ");
                input = Console.ReadLine();
            }
            break;    
    }
    Console.WriteLine();
    return number;
}

void FillArrayOfStrings(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"Введите строку № {i+1}: ");
        array[i] = Console.ReadLine();
    }
    Console.WriteLine();
}

void SelectStringsFromArray(string[] inputArray, out string[] outputArray, int maxLength)
{
    int count = 0;
    outputArray = new string[inputArray.Length];

    for (int i = 0; i < inputArray.Length; i++)
        if (inputArray[i].Length <= maxLength)
        {
            outputArray[count] = inputArray[i];
            count++;
        }
    
    Array.Resize(ref outputArray, count);
}

void PrintArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
        Console.WriteLine($"[{i}] {array[i]}");
        
    Console.WriteLine();
}