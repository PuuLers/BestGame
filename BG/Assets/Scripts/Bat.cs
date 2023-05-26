using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Bat : MonoBehaviour
    {
        public int Damage = 15;
        public int HP = 20;
        private Transform player;
        public float speed;
        public float agrodistance;
        private Animator animator;
        private bool AgroMode = true;

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

        void Update()
        {
            if (AgroMode == true)
            {
                Move();
            }
            if (HP <= 0)
            {
                animator.SetInteger("Bat states", 1);
                AgroMode = false;
            }
        }

        public void attacked()
        {
            Player.HelthPoint -= Damage;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                attacked();
            }
        }
    }
