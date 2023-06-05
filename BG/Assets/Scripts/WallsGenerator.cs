using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGeneratorCell
{
    public int X;
    public int Y;

    public bool WallLeft = true;
    public bool WallDown = true;

    public bool vesited = false;
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
                Walls[x, y] = new WallsGeneratorCell { X = x, Y = y };
            }

        }

        RemoveWallsWithBackTrecer(Walls);

        return Walls;
    }


    private void RemoveWallsWithBackTrecer(WallsGeneratorCell[,] Walls)
    {
        WallsGeneratorCell current = Walls[0, 0];
        current.vesited = true;
        Stack<WallsGeneratorCell> stack = new Stack<WallsGeneratorCell>();
        do
        {
            List<WallsGeneratorCell> unvisitedNeighbourse = new List<WallsGeneratorCell>();

            int X = current.X;
            int Y = current.Y;

            if (X > 0 && !Walls[X - 1, Y].vesited) unvisitedNeighbourse.Add(Walls[X - 1, Y]);
            if (X > 0 && !Walls[X, Y - 1].vesited) unvisitedNeighbourse.Add(Walls[X, Y - 1]);
            if (X < Width - 2 && !Walls[X + 1, Y].vesited) unvisitedNeighbourse.Add(Walls[X + 1, Y]);
            if (X < Width - 2 && !Walls[X, Y + 1].vesited) unvisitedNeighbourse.Add(Walls[X, Y + 1]);

            if (unvisitedNeighbourse.Count > 0)
            {
                WallsGeneratorCell chosen = unvisitedNeighbourse[UnityEngine.Random.Range(0, unvisitedNeighbourse.Count)];
                RemoveWall(current, chosen);
                chosen.vesited = true;
                current = chosen;
                stack.Push(chosen);
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }
    private void RemoveWall(WallsGeneratorCell a, WallsGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y == b.Y) a.WallLeft = false;
            else b.WallLeft = false;
        }
        else
        {
            if (a.X == b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }

}
