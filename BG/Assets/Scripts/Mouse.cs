using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Mouse : MonoBehaviour
{

    private Rigidbody2D rb;
    public Transform player;
    public float speed;
    public float agrodistance;
       

    void Start()
    {
        player  = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
    }
} 
