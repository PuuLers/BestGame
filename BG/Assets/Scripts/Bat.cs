using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Bat : MonoBehaviour
    {
        public int Damage = 15;
        public int HP = 20;
        private Transform player;
        private float playerX;
        public float speed;
        public float agrodistance;
        private Animator animator;
        private bool AgroMode = true;
        public float attackRate = 1.0f;
        public float attackDamage = 10.0f;
        private bool canAttack = true;
        private float timer = 0.0f;

    public void TakeDamage(int Damage)
        {
            HP -= Damage;
        }


        private void Move()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
            Vector3 LocalScale = Vector3.one;
            if (transform.position.x > player.position.x)
            {
                LocalScale.x = LocalScale.x * 1;
            }
            else
            {
                LocalScale.x = LocalScale.x * -1;
            }
            transform.localScale = LocalScale;
        }


        void Start()
        {
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        private void FindPlayerPositionX() 
        {
            playerX = GameObject.Find("Player").transform.position.x;
        }

        void Update()
        {
            FindPlayerPositionX();
            if (AgroMode == true)
            {
                Move();
            }
            if (HP <= 0)
            {
                animator.SetInteger("Bat states", 1);
                AgroMode = false;
            }
            if (playerX > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -15f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 15f);
            }

        if (canAttack)
        {
            Attack();
            timer = 0.0f;
            canAttack = false;
            {
                timer += Time.deltaTime;
                if (timer >= attackRate)
                {
                    canAttack = true;
                }
            }
        }

    }


    public void Attack()
    {
        Player.HelthPoint -= Damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Attack();
            }
        }
        
    }
