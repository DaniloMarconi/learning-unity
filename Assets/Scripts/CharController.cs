using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    private float horizontalInput;
    private bool isRight = true;
    private bool isJumping = false;
    private bool isOnGround = true;
    private bool isAttacking = false;

    [SerializeField]
    private float fallThreshold;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    private Vector2 respawn;
    public Rigidbody2D rb;
    public CharAnimationController charAnimationController;
    public GameObject hitBox;

    void Start()
    {
        this.respawn = new Vector2(this.transform.position.x, this.transform.position.y);
        this.rb = GetComponent<Rigidbody2D>();
        this.charAnimationController = GetComponent<CharAnimationController>();
    }

    void Update()
    {
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.isJumping = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        this.Jump();

        if (Input.GetKeyDown(KeyCode.U))
            this.Attack();
    }

    private void FixedUpdate()
    {
        this.HorizontalMove();
        this.Flip();
        this.GameOver();
    }

    private void HorizontalMove()
    {
        this.rb.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, rb.velocity.y);
        this.charAnimationController.SetWalk(horizontalInput != 0);
    }

    private void Flip()
    {
        if ((this.isRight && this.horizontalInput < 0f) || (!this.isRight && this.horizontalInput > 0f))
        {
            this.isRight = !this.isRight;

            Vector3 newScale = this.transform.localScale;
            newScale.z = newScale.z * -1;
            this.transform.localScale = newScale;

            Vector3 newScaleHB = this.hitBox.GetComponent<BoxCollider2D>().transform.localScale;
            newScaleHB.x = newScaleHB.x * -1;
            this.hitBox.GetComponent<BoxCollider2D>().transform.localScale = newScaleHB;
        }
    }

    private void Jump()
    {
        if (this.isJumping && this.isOnGround)
        {
            this.rb.AddForce(new Vector2(0f, this.jumpForce));
            this.isOnGround = false;
            this.charAnimationController.SetJump(this.isJumping);
        }
    }

    public void Attack()
    {
        if (!this.isAttacking)
        {
            this.charAnimationController.SetAttack(true);
            this.isAttacking = true;
            Invoke("StopAttack", 0.7f);
        }
    }

    public void StopAttack()
    {
        this.charAnimationController.SetAttack(false);
        this.isAttacking = false;
    }

    private void GameOver()
    {
        if (this.transform.position.y < this.fallThreshold)
            Invoke("Respawn", 0.5f);
    }

    private void Respawn()
    {
        this.transform.position = this.respawn;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)//Ground
        {
            this.isJumping = false;
            this.isOnGround = true;
            this.charAnimationController.SetJump(this.isJumping);
        }

        if (collision.gameObject.layer == 7)//Bomb
            this.Respawn();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }
}
