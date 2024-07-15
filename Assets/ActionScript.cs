using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : StateMachineBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private bool isRunning = false;
    private float doubleClickTime = 0.2f;
    private float lastClickTime = -1f;
    private float runSpeed = 5f;
    private float dashForce = 10f;
    private float jumpForce = 5f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        this.animator = animator;
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        HandleMovement();
        HandleJump();
        HandleAttack();
        HandleDash();
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (Time.time - lastClickTime < doubleClickTime)
            {
                isRunning = true;
                animator.SetTrigger("Run");
            }
            lastClickTime = Time.time;
        }

        if (isRunning)
        {
            animator.transform.Translate(Vector2.right * Time.deltaTime * runSpeed);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            isRunning = false;
            animator.ResetTrigger("Run");
        }
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            animator.SetTrigger("Attack");
        }
    }

    void HandleDash()
    {
        if (Input.GetMouseButtonDown(1)) // Right mouse button
        {
            animator.SetTrigger("Dash");
            rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }
    }
}


