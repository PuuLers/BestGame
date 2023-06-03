using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeftl = true;
    public bool WallDown = true;
}



public class WallsGenerator 
{
    public int Width = 20;
    public int Heigth = 20;

    public WallsGeneratorCell[,] Generate()
    {
        WallsGeneratorCell[,] Walls = new WallsGeneratorCell[Width, Heigth];

        for (int x = 0; x < Walls.GetLength(0); x++)
        {
            for (int y = 0; y < Walls.GetLength(1); y++)
            {
                Walls[x, y] = new WallsGeneratorCell { X = x, Y = y};
            }

        }



        return Walls;
    }
}
