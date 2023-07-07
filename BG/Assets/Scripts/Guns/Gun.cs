using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static int Damage = 10;
    [SerializeField] private Joystick JoystickGun;
    private float offset = 90;
    static public float rotZ;
    private float JoystickFireDistance = 0.7f;
    private Animator animator;
    [Range(0.1f, 10f)]
    public float FireSpeed = 1;
    public GameObject bullet;
    public Transform shotPoint;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    //вызывается в анимации
    private void fire()
    {
        Bullet.Damage = Damage;
        Instantiate(bullet, shotPoint.position, transform.rotation);
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


    void Update()
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    для ПК
        if (Mathf.Abs(JoystickGun.Horizontal) > 0.3f || Mathf.Abs(JoystickGun.Vertical) > 0.3f)
        {
            rotZ = Mathf.Atan2(JoystickGun.Horizontal, JoystickGun.Vertical) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + offset);

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

        if (JoystickGun.Horizontal > JoystickFireDistance || JoystickGun.Horizontal < -JoystickFireDistance || JoystickGun.Vertical > JoystickFireDistance || JoystickGun.Vertical < -JoystickFireDistance)
        {
            Player.ShootingMode = true;
        }
        else
        {
            Player.ShootingMode = false;
        }
        Animation();
    }
}
