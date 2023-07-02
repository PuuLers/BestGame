using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AK : Gun
{
    public GameObject bullet;
    public Transform shotPoint;
    public Animator animator;
    
    public static int Damage = 10;

    //вызывается в анимации
    private void fire()
    {
        Bullet.Damage = Damage;
        Instantiate(bullet, shotPoint.position, transform.rotation);
        animator.Play("shoot");
    }


    private void Update()
    {

        if (Player.ShootingMode == true)
        {
            animator.SetBool("Shoot", true);
        }
        else
        {
            animator.SetBool("Shoot", false);
        }


    }
}