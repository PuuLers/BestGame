using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsSpawner : MonoBehaviour
{
    [SerializeField]public GameObject PrefabCell;

    //хуй я клал

    private void Start()
    {
        WallsGenerator Generator = new WallsGenerator();
        WallsGeneratorCell[,] Walls = Generator.Generate();

        for (int x = 0; x < Walls.GetLength(0); x++)
        {
            for (int y = 0; y < Walls.GetLength(1); y++)
            {
                Cell c = Instantiate(PrefabCell, new Vector2(x, y), Quaternion.identity).GetComponent<Cell>();
                c.Wallleft.SetActive(Walls[x, y].WallLeft);
                c.WallDown.SetActive(Walls[x, y].WallDown);
            }

        }

    }

}
