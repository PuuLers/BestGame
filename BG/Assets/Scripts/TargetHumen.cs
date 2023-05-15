using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetHumen : MonoBehaviour
{
    public static int HP = 20;
    private Animator animator;
    private void fall()
    {
        animator.Play("fall");
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }


    private void Update()
    {
        if (HP < 0)
        {
            fall();
        }
    }
}
