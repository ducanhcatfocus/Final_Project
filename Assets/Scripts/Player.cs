using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float xInput;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 1f;
    Rigidbody2D rb;
    Animator animator;
  


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
        AnimationController();
        Flip();
    }

    void PlayerJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }

    void AnimationController()
    {
        bool isMoving = xInput != 0;
        animator.SetBool("isMove", isMoving);

    }

    void Flip()
    {
        transform.Rotate(0,xInput,0);
    }
}
