using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject Cell;
    [SerializeField] private Transform Zero;
    public int Widgh, Height;
    private int SpawnChence;

    private void Start()
    {
        Generate();
    }

    private void Update()
    {
        SpawnChence = Random.Range(0, 2);
        Debug.Log(SpawnChence);
    }
    private void Generate()
    {
        for (int y = 0; y < Height; y++)
        {
            if (SpawnChence >= 0.5f)
            {
                var Ycell = Instantiate(Cell, Zero);
                Ycell.transform.position = new Vector3(0, y, 0);
            }

            for (int x = 0; x < Widgh; x++)
            {
                var Xcell = Instantiate(Cell, Zero);
                Xcell.transform.position = new Vector3(x, y, 0);
            }
        }
    }
    













}
