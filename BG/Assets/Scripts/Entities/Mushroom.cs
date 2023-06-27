using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public int Damage = 20;
    public int HP = 50;
    private Transform player;
    public Transform spawnPoint;
    public float agrodistance;
    private float distance;
    private Animator animator;
    private bool AgroMode = false;
    public GameObject projectileWitch;
    private float fireCooldown = 1f;
    public float bulletSpeed;
    private bool isShooting = false;

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
            if (!isShooting)
            {
                StartCoroutine(AttackDelay());
            }
            IEnumerator AttackDelay()
            {
                isShooting = true;
                yield return new WaitForSeconds(fireCooldown);
                LrAttack();
                isShooting = false;
            }
        }
        if (HP <= 0)
        {
            //animator.SetInteger("Mushroom states", 1);
            AgroMode = false;
            agrodistance = 0;
            Destroy(gameObject);
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

    public void LrAttack()
    {
        Vector2 direction = player.position - spawnPoint.position;
        spawnPoint.right = direction;
        GameObject bullet = Instantiate(projectileWitch, spawnPoint.position, Quaternion.identity);
        bullet.transform.right = direction;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }

}
