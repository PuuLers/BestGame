using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : MonoBehaviour
{
    public static int Damage = 10;
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;

    private float Reload;
    public float startTimeBtwShots;
    public Animator animator;
    private void fire()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        Reload = startTimeBtwShots;
        animator.Play("shoot");
    }
    private void Update()
    {
        Vector3 difference= Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;   
        transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + offset);
        Bullet.Damage = Damage;
        if (Reload <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                animator.SetBool("Shoot", true);
                fire();

            }
            else
            {
                animator.SetBool("Shoot", false);
            }
        }
        else 
        {
            Reload -= Time.deltaTime;
        }
      
            
    }
}