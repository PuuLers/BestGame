using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D Rigidbody;
    private Vector2 MoveVector;

    //start и awake почти одна хуйня
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveVector.x = Input.GetAxisRaw("Horizontal");
        MoveVector.y = Input.GetAxisRaw("Vertical");
    }
    //для физического перемещения нужно использовать FixedUpdate
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + MoveVector * Speed * Time.fixedDeltaTime);
    }
}