//class Program
//{
//    static void Main()
//    {
//        Bits fromLong = 1234567890123456789L;
//        Bits fromInt = 12345;
//        Bits fromByte = 123;

//        System.Console.WriteLine(fromLong);
//        System.Console.WriteLine(fromInt);
//        System.Console.WriteLine(fromByte);
//    }
//}

using System;

class Program
{
    static void Main()
    {
        int[,] labyrinth = new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 1},
            {1, 0, 1, 1, 1, 0, 1},
            {0, 0, 0, 0, 1, 0, 0},
            {1, 1, 0, 0, 1, 1, 1},
            {1, 1, 1, 0, 1, 1, 1},
            {1, 1, 1, 0, 1, 1, 1}
        };

        int startI = 3; // Начальная строка
        int startJ = 0; // Начальный столбец
        Console.WriteLine("Всего выходов из начальной точки: " + HasExit(startI, startJ, labyrinth));
    }

    static int HasExit(int startI, int startJ, int[,] labyrinth)
    {
        int rows = labyrinth.GetLength(0);
        int cols = labyrinth.GetLength(1);
        bool[,] visited = new bool[rows, cols];
        return CountExits(startI, startJ, labyrinth, visited);
    }

    static int CountExits(int i, int j, int[,] labyrinth, bool[,] visited)
    {
        if (i < 0 || i >= labyrinth.GetLength(0) || j < 0 || j >= labyrinth.GetLength(1))
            return 0; // За пределами

        if (visited[i, j] || labyrinth[i, j] == 1)
            return 0; // Стена или уже посещенная

        visited[i, j] = true; // Отметьте эту ячейку как посещенную

        // Проверьте, не является ли эта клетка краевой, которая может быть выходом (но не начальной клеткой, если она краевая).
        int exitCount = (i == 0 || i == labyrinth.GetLength(0) - 1 || j == 0 || j == labyrinth.GetLength(1) - 1) ? 1 : 0;

        // Повторите для всех соединенных клеток
        exitCount += CountExits(i - 1, j, labyrinth, visited);
        exitCount += CountExits(i + 1, j, labyrinth, visited);
        exitCount += CountExits(i, j - 1, labyrinth, visited);
        exitCount += CountExits(i, j + 1, labyrinth, visited);

        return exitCount;
    }
}