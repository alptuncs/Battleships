using System;

namespace Battleships;

public class AsciiBoard : IAsciiGameObject
{
    private int width;
    private int height;

    public char[,] Graphics { get; }

    public AsciiBoard(int width, int height)
    {
        this.width = width;
        this.height = height;
        Graphics = new char[width, height];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Graphics[i, j] = '*';
            }
        }
    }

}
