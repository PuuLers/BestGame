using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DecorGenerator : MonoBehaviour
{
    public int numberObject; //количеств обьектов
    public GameObject[] objects; //массив объектов
    private int generatedObjects = 0;
    public float minRange, maxRange; //территория спавна
    
    void Update()
    {
        //считает сколько объектов заспавненно
        if (generatedObjects <= numberObject)
        {
            Generate();
            generatedObjects++;
        }
    }
     public void Generate()
     {
        int rand = Random.Range(0, objects.Length);
        var cell = Instantiate(objects[rand], transform.position, Quaternion.identity);
        cell.transform.position = new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), transform.position.z);
     }    



}
