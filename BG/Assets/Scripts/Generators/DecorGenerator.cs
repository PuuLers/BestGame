using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DecorGenerator : MonoBehaviour
{
    public int numberObject; //��������� ��������
    public GameObject[] objects; //������ ��������
    private int generatedObjects = 0;
    public float minRange, maxRange; //���������� ������
    
    void Update()
    {
        //������� ������� �������� �����������
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
