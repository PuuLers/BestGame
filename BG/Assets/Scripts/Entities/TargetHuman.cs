using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHuman : ENEMY
{

    private Animator animator;
    private void fall()
    {
        if (HP <= 0)
        {
            animator.SetBool("deadtarget", true);
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
    }



    private void Update()
    {
        fall();
        Death();
    }
}







