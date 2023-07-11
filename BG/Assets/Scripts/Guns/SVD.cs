using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVD : Gun
{
    public Animator animator;
    [Range(0.1f, 10f)]
    public float FireSpeed = 1;
    public GameObject bullet;
    public Transform shotPoint;


    private void fire()//���������� � ��������
    {
        Bullet.Damage = Damage;
        Instantiate(bullet, shotPoint.position, transform.rotation);
    }

    private void Update()
    {
        Animation();

    }
    private void Animation()
    {
        if (Player.ShootingMode == true)
        {
            animator.SetBool("Shoot", true);
            animator.speed = FireSpeed;
        }
        else
        {
            animator.SetBool("Shoot", false);
            animator.speed = 1;
        }
    }
}
