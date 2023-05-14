using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D Rigidbody;
    private Vector2 MoveVector;

   
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveVector.x = Input.GetAxisRaw("Horizontal");
        MoveVector.y = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + MoveVector * Speed * Time.fixedDeltaTime);
    }
}