using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGenerator : MonoBehaviour
{
    public GameObject[] Room;
    public Transform Zero;
    public int Height, Width;
    public int prefX;
    public int prefY;

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for (int x = 0; x < Width; x++)
        {
            int randX = Random.Range(0, Room.Length);
            var cellX = Instantiate(Room[randX], Zero);
            cellX.transform.localPosition = new Vector3(x * prefX, 0, 0);
            for (int y = 1; y < Height; y++)
            {
                int randY = Random.Range(0, Room.Length);
                var cellY = Instantiate(Room[randY], Zero);
                cellY.transform.localPosition = new Vector3(x * prefY, y * prefY, 0);
            }
        }
    }
}
