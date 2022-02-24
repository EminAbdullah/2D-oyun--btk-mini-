using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB;
    Animator playerAnimator;
    public float jumpSpeed = 1f,jumpFrequency= 0.1f, nextJumpTime;
    public float moveSpeed = 1f;

    bool facingRight=true;
    public bool isGrounded = false;
    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;
    
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        horizontalMove();
        OnGroundCheck();

        if (playerRB.velocity.x<0 && facingRight)
        {
            flipFace();
        }
        else if (playerRB.velocity.x>0 && !facingRight)
        {
            flipFace();
        }

        if (Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime<Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            jump();
        }
    }

    void horizontalMove()
    {

        playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, playerRB.velocity.y);
        playerAnimator.SetFloat("PlayerSpeed",Mathf.Abs( playerRB.velocity.x));
    }

    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 TempLocalScale = transform.localScale;
        TempLocalScale.x *= -1;
        transform.localScale = TempLocalScale;
    }

    private void jump()
    {
        playerRB.AddForce(new Vector2(0f,jumpSpeed));
    }

    void OnGroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
