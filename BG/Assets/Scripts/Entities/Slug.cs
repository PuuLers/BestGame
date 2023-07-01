using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Slug : MonoBehaviour
{
    public int Damage = 10;
    public int HP = 10;
    public float speed;
    public float agrodistance;
    private float distance;
    private bool AgroMode = false;
    private bool isAttacking = false;
    public float raycastDistance = 10f;
    public float CloseAttackDelay = 2f;
    private float nextAttackTime = 0f;
    private Animator animator;
    public GameObject projectileSlug;
    public float startTimeBtwShots;
    private float fireCooldown = 0.6f;
    public float bulletSpeed;
    public Transform shotPoint;
    private Transform player;



    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        DistanceCheck();

        if (AgroMode == true)
        {
            Move();
            closeAttack();



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

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
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

    public void closeAttack()
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
                    nextAttackTime = Time.time + CloseAttackDelay;
                }
            }
        }

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


}

