using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mouse : MonoBehaviour
{
    public int Damage = 10;
    public int HP = 10;
    private Transform player;
    public float speed;
    public float agrodistance;
    private float distance;
    private Animator animator;
    private bool AgroMode = false;
    public float raycastDistance = 10f;
    public float attackDelay = 2f; 
    private float nextAttackTime = 0f;



    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }


    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        Vector3 LocalScale = Vector3.one;
        if (transform.position.x > player.position.x)
        {
            LocalScale.x = LocalScale.x * 1;
        }
        else
        {
            LocalScale.x = LocalScale.x * -1;
        }
        transform.localScale = LocalScale;
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        DistanceCheck();
        if (AgroMode == true)
        {
            Move();
            Attack();
        }
        if (HP <= 0)
        {
            animator.SetInteger("Mouse states", 1);
            AgroMode = false;
            agrodistance = 0;
        }
        
    }

    public void Attack()
    {
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = transform.right;
        RaycastHit2D hitinfo = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                if (Time.time > nextAttackTime)
                {
                    Player.HealthPoint -= Damage;
                    nextAttackTime = Time.time + attackDelay;
                }
            }
        }

    }


    public void DistanceCheck()
    {
        distance = Vector3.Distance(player.position, transform.position);
        if (distance < agrodistance)
        {
            AgroMode = true;
        }
        else
        {
           AgroMode = false;
        }
    }        
}