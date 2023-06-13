using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Slug : MonoBehaviour
{
    public int Damage = 10;
    public int HP = 10;
    private Transform player;
    public float speed;
    public float agrodistance;
    public float distance;
    private Animator animator;
    private bool AgroMode = false;
    public float startTimeBtwShots;
    public GameObject projectileSlug;
    private float fireCooldown = 0.6f;
    public float bulletSpeed = 50;
    public Transform shotPoint;
    private bool isAttacking = false;
    

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
            LocalScale.x = LocalScale.x * -1;
        }
        else
        {
            LocalScale.x = LocalScale.x * 1;
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
            CloseAttack();
            if (!isAttacking)
            {
                StartCoroutine(AttackDelay());
            }
            IEnumerator AttackDelay()
            {
                isAttacking = true;
                yield return new WaitForSeconds(fireCooldown);
                LrAttack();
                isAttacking = false;
            }
        }
        if (HP <= 0)
        {
            animator.SetInteger("Slug states", 1);
            AgroMode = false;
            agrodistance = 0;
        }
    }

    public void CloseAttack()
    {
        Player.HelthPoint -= Damage;
    }

    public void LrAttack()
    {
       Vector2 direction = player.position - transform.position;
       shotPoint.right = direction;
       GameObject bullet = Instantiate(projectileSlug, shotPoint.position, Quaternion.identity);
       bullet.transform.right = direction;  
       Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
       bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CloseAttack();
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

