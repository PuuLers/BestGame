using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stave : MonoBehaviour
{
    public int Damage = 10;
    public float agrodistance;
    private float distance;
    private bool AgroMode = false;
    private bool isAttacking = false;
    public GameObject projectileIce;
    public float startTimeBtwShots;
    private float fireCooldown = 0.6f;
    public float bulletSpeed;
    public Transform shotPoint;
    private Transform player;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    private void Update()
    {
        DistanceCheck();

        if (AgroMode == true)
        {
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
        Vector2 direction = player.position - transform.position;
        shotPoint.right = direction;
        GameObject bullet = Instantiate(projectileIce, shotPoint.position, Quaternion.identity);
        bullet.transform.right = direction;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }
}
