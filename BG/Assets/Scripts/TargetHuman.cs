using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHuman : MonoBehaviour
{
    public int HP = 1;
    private Animator animator;
    private void fall()
    {
        animator.SetBool("deadtarget", true);
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
        if (HP <= 0)
        {
            fall();
        }
    }
}







