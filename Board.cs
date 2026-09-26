public class Board
{
    private char[] cells = new char[9];

    public Board()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = ' ';
        }
    }

    public void Display()
    {
        Console.WriteLine($"{cells[0]} | {cells[1]} | {cells[2]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{cells[3]} | {cells[4]} | {cells[5]}");
        Console.WriteLine("--+---+--");
        Console.WriteLine($"{cells[6]} | {cells[7]} | {cells[8]}");
    }


    public bool MakeMove(int position, char symbol)
    {
        if (position < 0 || position > 8)
        {
            return false;
        }

        if (cells[position] == ' ')
        {
            cells[position] = symbol;
            return true;
        }

        return false;
    }

    public bool IsWinner(char symbol)
    {
        return
            (cells[0] == symbol && cells[1] == symbol && cells[2] == symbol) ||
            (cells[3] == symbol && cells[4] == symbol && cells[5] == symbol) ||
            (cells[6] == symbol && cells[7] == symbol && cells[8] == symbol) ||

            (cells[0] == symbol && cells[3] == symbol && cells[6] == symbol) ||
            (cells[1] == symbol && cells[4] == symbol && cells[7] == symbol) ||
            (cells[2] == symbol && cells[5] == symbol && cells[8] == symbol) ||

            (cells[0] == symbol && cells[4] == symbol && cells[8] == symbol) ||
            (cells[2] == symbol && cells[4] == symbol && cells[6] == symbol);
    }
    public bool IsFull()
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i] == ' ')
            {
                return false;
            }
        }

        return true;
    }
    public char[] GetCells()
    {
        return cells;
    }
}