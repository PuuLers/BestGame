using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AK : MonoBehaviour
{
    public static int Damage = 10;
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    private float Reload;
    public float startTimeBtwShots;
    public Animator animator;
    public Joystick JoystickGun;
    static public float rotZ;
    public float JoystickFireDistance = 0.7f;


    private void fire()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        Reload = startTimeBtwShots;
        animator.Play("shoot");
    }
    private void Update()
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    äëÿ ÏÊ
        if (Mathf.Abs(JoystickGun.Horizontal) > 0.3f || Mathf.Abs(JoystickGun.Vertical) > 0.3f)
        {
            rotZ = Mathf.Atan2(JoystickGun.Horizontal, JoystickGun.Vertical) * Mathf.Rad2Deg;
        }
       
        transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + offset);

        Bullet.Damage = Damage;



        Vector3 LocalScale = Vector3.one;
        if (rotZ < 0 || rotZ > 180)
        {
            LocalScale.y = LocalScale.y * -1f;
        }
        else
        {
            LocalScale.y = LocalScale.y * +1f;
        }
        transform.localScale = LocalScale;


        if (Reload <= 0)
        {
            if (JoystickGun.Horizontal > JoystickFireDistance || JoystickGun.Horizontal < -JoystickFireDistance || JoystickGun.Vertical > JoystickFireDistance || JoystickGun.Vertical < -JoystickFireDistance)
            {
                animator.SetBool("Shoot", true);
                fire();
                Player.ShootingMode = true;
            }
            else
            {
                animator.SetBool("Shoot", false);
                Player.ShootingMode = false;
            }
        }
        else 
        {
            Reload -= Time.deltaTime;
        }
        
            
    }
}