using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    Vector3 pos;
    Camera main;
    private void Start()
    {
        main = FindObjectOfType<Camera>();
    }
   
    void Update()
    {
        Flip();
       pos = main.WorldToScreenPoint(transform.position);
    }

    void Flip()
    {
        if (Input.mousePosition.x < pos.x);
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.mousePosition.x > pos.x);
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}