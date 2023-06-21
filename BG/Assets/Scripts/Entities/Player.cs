using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    static public float Experience;
    public Image EXPBar;
    public Image HPBar;
    private float NormalizedSpeed;
    private float ShootingSpeed;
    static public bool ShootingMode = false;
    static public float HealthPoint = 100;
    public float Speed = 10f;
    private Rigidbody2D Rigidbody;
    private Vector2 MoveVector;
    private Animator anim;
    public Joystick JoystickMove;
    public Joystick JoystickGun;
    private SpriteRenderer sprite;


    private void ShowIndicators()
    {
        HPBar.fillAmount = HealthPoint / 100f;
        EXPBar.fillAmount = Experience / 100f;
    }


    public void Hit()
    {
        anim.SetBool("Player hit", true);
    }

    void Start()
    {
        //инициализация компонентов 
        Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        //присвоение значений и стабилизация скорости
        ShootingSpeed = Speed / 2;
        NormalizedSpeed = Speed;
    }
    void Update()
    {
        //выводим показатели
        ShowIndicators();
        Debug.Log(MoveVector.x);
        //замедление во время стрельбы
        if (ShootingMode == true)
        {
            Speed = ShootingSpeed;
            if(AK.rotZ < 0 || AK.rotZ > 180)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }
        else
        {
            Speed = NormalizedSpeed;
        }
        //проверка здоровья
        if (HealthPoint <= 0)
        {
            Debug.Log("ТЫ СДОХ НАХУЙ");
        }
        //реализация поворота и джостика
        MoveVector.x = JoystickMove.Horizontal;
        MoveVector.y = JoystickMove.Vertical;
        if (MoveVector.x > 0f && !ShootingMode)
        {
            sprite.flipX = false;
        }
        else if (MoveVector.x < 0f && !ShootingMode)
        {
            sprite.flipX = true;
        }
        //анимации
        if (MoveVector.x != 0 || MoveVector.y != 0)
        {
            anim.SetInteger("Players states", 1);
        }
        else
        {
            anim.SetInteger("Players states", 0);
        }

    }
    
    private void FixedUpdate()
    {
        Rigidbody.MovePosition(Rigidbody.position + MoveVector * Speed * Time.fixedDeltaTime);
    }
    public void TakeDamage(int Damage)
    {
        HealthPoint -= Damage;
    }



}
