using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Witch : MonoBehaviour
{

    public int Damage = 20;
    public int HP = 50;
    private Transform player;
    public Transform shotPoint;
    public float speed;
    public float agrodistance;
    private float distance;
    private Animator animator;
    private bool AgroMode = false;
    public GameObject projectileWitch;
    public GameObject bat;
    public GameObject mushroom;
    private float fireCooldown = 5f;
    public float spawnCooldown = 10f;
    public float bulletSpeed;
    private bool isAttacking = false;
    public int batCount;
    public float attackDelay = 2f;
    private float nextAttackTime = 0f;
    public static float exp;
   

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
            SpecialAttack();

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
            animator.SetInteger("Witch states", 2);
            AgroMode = false;
            agrodistance = 0;
        }
    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        if (AgroMode == true)
        {
            if (Time.time > nextAttackTime)
            {
                SpawnBats();
                bat.transform.parent = null;
                nextAttackTime = Time.time + attackDelay;
            }
        }
    }

    void SpawnBats()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 batPosition = transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-1f, 1f), 0);
            Instantiate(bat, batPosition, Quaternion.identity);
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
            animator.SetInteger("Witch states", 0);
        }
    }

    private void Move()
    {
        animator.SetInteger("Witch states", 1);
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

    public void LrAttack()
    {
        Vector2 direction = player.position - transform.position;
        shotPoint.right = direction;
        GameObject bullet = Instantiate(projectileWitch, shotPoint.position, Quaternion.identity);
        bullet.transform.right = direction;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }
    public void SpecialAttack()
    {   
        if (exp >= 50)
        {
            Instantiate(mushroom, transform.position, Quaternion.identity);
            exp = 0;
        }
    }



}
