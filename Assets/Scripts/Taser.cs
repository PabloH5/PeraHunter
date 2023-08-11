using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taser : MonoBehaviour
{
    Animator animator;
    public float coolDown = 0.0f;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Attack2()
    {
        animator.SetBool("isAttack", true);
        Invoke(nameof(Stop), coolDown);
    }
    private void Stop()
    {
        animator.SetBool("isAttack", false);
        // this.gameObject.SetActive(false);
    }


}
