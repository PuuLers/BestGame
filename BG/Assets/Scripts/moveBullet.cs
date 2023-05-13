using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBullet : MonoBehaviour
{
    public float Speed;
    public int Damage;
    private Vector2 Move;
    private Rigidbody2D Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
}
