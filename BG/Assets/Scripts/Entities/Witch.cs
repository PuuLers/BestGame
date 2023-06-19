using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Witch : MonoBehaviour
{

    public int Damage = 20;
    public int HP = 50;
    private Transform player;
    public float speed;
    public float agrodistance;
    private float distance;
    private Animator animator;
    private bool AgroMode = false;
    public float startTimeBtwShots;
    public GameObject projectileWitch;
    private float fireCooldown = 0.6f;
    public float bulletSpeed;
    public Transform shotPoint;
    private bool isAttacking = false;
    public GameObject bat;
    public int batCount;
    public float CloseAttackDelay = 2f;
    private float nextAttackTime = 0f;

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        if (AgroMode == true)
        {
            for (int i = 0; i < batCount; i++)
            {
                if (Time.time > nextAttackTime)
                {
                    Instantiate(bat, transform);
                    nextAttackTime = Time.time + CloseAttackDelay;
                }

            }
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
            //animator.SetInteger("Slug states", 1);
            AgroMode = false;
            agrodistance = 0;
        }
    }

   

    public void LrAttack()
    {
        Vector2 direction = player.position - transform.position;
        shotPoint.right = direction;
        GameObject bullet = Instantiate(projectileWitch, shotPoint.position, Quaternion.identity);
        bullet.transform.right = direction;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
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
