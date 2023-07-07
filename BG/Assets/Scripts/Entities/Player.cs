using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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
    static public float HealthPoint = 100f;
    public float Speed = 10f;
    static public float playerFreeze;
    private Rigidbody2D Rigidbody;
    private Vector2 MoveVector;
    private Animator anim;
    public Joystick JoystickMove;
    public Joystick JoystickGun;
    private SpriteRenderer sprite;
    public GameObject[] Guns;
    public int GunID;

    private void RandomGun()
    {
        GunID = UnityEngine.Random.Range(0, 13);
        if (GunID >= 0 && GunID < Guns.Length)
        {
            Guns[GunID].SetActive(true);
        }
    }





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
        //RandomGun();
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
        //замедление во время стрельбы
        if (ShootingMode == true)
        {
            anim.speed = 0.5f;
            Speed = ShootingSpeed;
            if (Gun.rotZ < 0 || Gun.rotZ > 180)
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
            anim.speed = 1f;
            Speed = NormalizedSpeed;
        }
        IEnumerator DelayedPlayerFreeze()
        {
            yield return new WaitForSeconds(2f);
            playerFreeze = 0;
        }

        if (playerFreeze > 0)
        {
            Speed -= playerFreeze;
        }

        if (playerFreeze == 5)
        {
            StartCoroutine(DelayedPlayerFreeze());
            Speed = 0;
        }
        //проверка здоровья
        if (HealthPoint <= 0)
        {
            Debug.Log("ТЫ СДОХ НАХУЙ");
        }
        //реализация поворота и джойстика
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
