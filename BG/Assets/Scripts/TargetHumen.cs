using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TargetHumen : MonoBehaviour
{
    public static int HP = 1;
    public Animator animator;
    private void fall()
    {
        animator.SetBool("deadtarget", true);
    }
    private void Update()
    {
        if (HP < 0)
        {
            fall();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            HP = HP - Bullet.Damage;
            Debug.Log("gdfgdfgd");
        }


    }
}
