using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public class Bat : MonoBehaviour
    {
        public int Damage = 15;
        public int HP = 20;
        private Transform player;
        public float speed;
        public float agrodistance;
        public float distance;
        private Animator animator;
        private bool AgroMode = true;
        public float attackRate = 1.0f;
        private bool canAttack = true;
        private float timer = 0.0f;

        public void TakeDamage(int Damage)
        {
            HP -= Damage;
        }


        private void Move()
        {
          transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
          if (player.position.x > transform.position.x)
          {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -15f);
          }
          else
          {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 15f);
          }
        }  


        void Start()
        {
            animator = GetComponent<Animator>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }

        void Update()
        {
            DistanceCheck();
            if (AgroMode == true)
            {
                Move();
            }
            if (HP <= 0)
            {
                animator.SetInteger("Bat states", 1);
                AgroMode = false;
                agrodistance = 0;
            }
            if (canAttack)
            {
                Attack();
                timer = 0.2f;
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

    }   
