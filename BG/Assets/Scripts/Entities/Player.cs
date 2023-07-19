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
    static public bool playerCombustion;
    private float freezeDelay = 1f;
    private float freezeTime = 0f;
    private float burningDuration = 3f;
    private float burningTime = 0f;
    private float burnTickRate = 1f;
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
        //������������� ����������� 
        Rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        //���������� �������� � ������������ ��������
        ShootingSpeed = Speed / 2;
        NormalizedSpeed = Speed;
    }
    void Update()
    {
        //Debug.Log(playerFreeze);
        //������� ����������
        ShowIndicators();
        //���������� �� ����� ��������
        if (ShootingMode == true)
        {
            anim.speed = 0.5f;
            Speed = ShootingSpeed;
            if (AK.rotZ < 0 || AK.rotZ > 180)
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

        if (playerCombustion)
        {
            burningTime += Time.deltaTime;

            if (burningTime >= burningDuration)
            {
                StopBurning();
            }
            if (burningTime % burnTickRate < Time.deltaTime)
            {
                ApplyBurnDamage();
            }
        }

        //�������� ��������
        if (HealthPoint <= 0)
        {
            Debug.Log("�� ���� �����");
        }
        //���������� �������� � ����    �����
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
        //��������
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

    public void StartBurning()
    {
        if (!playerCombustion)
        {
            playerCombustion = true;
            burningTime = 0f;
            Debug.Log("Player starts burning");
        }
    }

    private void StopBurning()
    {
        if (playerCombustion)
        {
            playerCombustion = false;
            Debug.Log("Player stops burning");
        }
    }

    private void ApplyBurnDamage()
    {
        HealthPoint -= 10f;
    }
}


