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
        if (rotZ < 0 || rotZ > 180)
        {
            LocalScale.y = LocalScale.y * -1f;
            Debug.Log(1);
        }
        else
        {
            LocalScale.y = LocalScale.y * +1f;
        }
        transform.localScale = LocalScale;

        if (MoveVector.x != 0 || MoveVector.y != 0)
        {
            anim.SetInteger("Players states", 1);
        }
        else
        {
            anim.SetInteger("Players states", 0);
        }

    }
    
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + MoveVector * Speed * Time.fixedDeltaTime);
    }

    

}
