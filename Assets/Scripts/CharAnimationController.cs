using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimationController : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetWalk(bool isWalking)
    {
        this.animator.SetBool("isWalking", isWalking);
    }

    public void SetJump(bool isJumping)
    {
        this.animator.SetBool("isJumping", isJumping);
    }

    public void SetAttack(bool isAttacking)
    {
        this.animator.SetBool("isAttacking", isAttacking);
    }
}
