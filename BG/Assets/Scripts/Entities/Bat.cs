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
        private float distance;
        private Animator animator;
        private bool AgroMode = true;
        public float raycastDistance = 10f;
        public float attackDelay = 2f;
        private float nextAttackTime = 0f;

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
                Attack();               
            }
            if (HP <= 0)
            {
                animator.SetInteger("Bat states", 1);
                AgroMode = false;
                agrodistance = 0;
            }
        }


    public void Attack()
    {
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = transform.right;
        RaycastHit2D hitinfo = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                if (Time.time > nextAttackTime)
                {
                    Player.HealthPoint -= Damage;
                    nextAttackTime = Time.time + attackDelay;
                }
            }
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
