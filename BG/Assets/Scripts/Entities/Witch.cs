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

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        for (int i = 0; i < batCount; i++) 
        {
            Instantiate(bat);
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
            LrAttack(); 


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
      Instantiate(projectileWitch);
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
