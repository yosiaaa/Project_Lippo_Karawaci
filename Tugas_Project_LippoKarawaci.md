Tugas Algoritma & Database SQL Query
------------------------------------

Algoritma #1
------------
```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter numbers separated by commas: ");
        string input = Console.ReadLine();

        string[] numberStrings = input.Split(',');

        int total = CalculateTotal(numberStrings);

        Console.WriteLine("Total: " + total);
    }

    private static int CalculateTotal(string[] numberStrings)
    {
        int total = 0;
        foreach (string numberString in numberStrings)
        {
            if (int.TryParse(numberString, out int number))
            {
                if (number == 8)
                {
                    total += 5;
                }
                else if (number % 2 == 0)
                {
                    total += 1;
                }
                else
                {
                    total += 3;
                }
            }
            else
            {
                Console.WriteLine($"Invalid number: {numberString}. Skipping...");
            }
        }
        return total;
    }
}
```

Algoritma #2 A
--------------

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Masukkan nilai n: ");
        int nilai = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= nilai; i++)
        {
            int angka = i;
            for (int j = 1; j <= i; j++)
            {
                Console.Write(angka);
            }
            Console.WriteLine();
        }
    }
}
```

Algoritma #2 B
--------------

```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Masukkan nilai n: ");
        int nilai = Convert.ToInt32(Console.ReadLine());

        for (int i = 1; i <= nilai; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(i - j + 1);
            }

            Console.WriteLine();
        }
    }
}
```

Algoritma #2 C
--------------
```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Masukkan nilai n: ");
        int nilai = Convert.ToInt32(Console.ReadLine());
        int k = 1;
        int increment = 1;

        for (int i = 1; i <= nilai; i++)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(k);

                if (k == nilai)
                {
                    increment = -1;
                }
                else if (k == 1)
                {
                    increment = 1;
                }

                k += increment;
            }

            Console.WriteLine();
        }
    }
}
```

Algoritma #2 D
--------------
```csharp
using System;

public class Program
{
    public static void Main()
    {
        Console.Write("Masukkan nilai n: ");
        int nilai = Convert.ToInt32(Console.ReadLine());

        int[,] matrix = new int[nilai, nilai];
        int currentNumber = 1;

        for (int i = 0; i < nilai; i++)
        {
            for (int j = 0; j < nilai; j++)
            {
                matrix[i, j] = currentNumber++;
            }
            
            // Jika baris ganjil, reverse nilai dalam baris
            if (i % 2 != 0)
            {
                Array.Reverse(matrix, i * nilai, nilai);
            }
        }

        // Cetak matriks
        for (int i = 0; i < nilai; i++)
        {
            for (int j = 0; j < nilai; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
```

Database Query #1
-----------------

`
SELECT column_name, COUNT(column_name) AS duplicate_count
FROM table_name
GROUP BY column_name
HAVING COUNT(column_name) > 1;
`

Database Query #2
-----------------

`
SELECT TableA.column_name
FROM TableA
LEFT JOIN TableB ON TableA.column_name = TableB.column_name
WHERE TableB.column_name IS NULL;
`
