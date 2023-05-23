using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 10f;
    private Rigidbody2D Rigidbody;
    private Vector2 MoveVector;
    public Animator anim;

   
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveVector.x = Input.GetAxisRaw("Horizontal");
        MoveVector.y = Input.GetAxisRaw("Vertical");
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        Vector3 LocalScale = Vector3.one;

        if (rotZ > 90 || rotZ < -90)
        {
            LocalScale.y = -1f;
        }
        else
        {
            LocalScale.y = +1f;
        }

        if (MoveVector.x != 0 || MoveVector.y != 0)
        {
            anim.SetInteger("Players ST", 1);
        }
        else
        {
            anim.SetInteger("Players ST", 0);
        }

    }
    
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + MoveVector * Speed * Time.fixedDeltaTime);
    }

    

}
