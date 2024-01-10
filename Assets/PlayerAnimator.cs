using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Player player;
    public float MoveX { get; set; }
    public float MoveY { get; set; }
    public bool IsMoving { get; set; }

    private bool isAttacking = false;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    void Update()
    {

        if (!isAttacking && Input.GetMouseButtonDown(0) && tag == "Player")
        {
            StartCoroutine(AttackAnimation());
        }

        if (IsMoving)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        if (!isAttacking)
        {
            // Check movement direction and set animator parameters
            SetMovementAnimations();
        }

        // Handle other logic...
    }

    void SetMovementAnimations()
    {
        if (MoveX == 1)
        {
            animator.SetFloat("moveX", 1f);
        }
        else if (MoveX == -1)
        {
            animator.SetFloat("moveX", -1f);
        }
        else if (MoveX == -1 && MoveY == 1)
        {
            animator.SetFloat("moveY", 0.4f);
        }
        else if (MoveX == -1 && MoveY == -1)
        {
            animator.SetFloat("moveY", 1f);
        }
        else if (MoveX == 1 && MoveY == 1)
        {
            animator.SetFloat("moveY", 1f);
        }
        else if (MoveX == 1 && MoveY == -1)
        {
            animator.SetFloat("moveY", -0.4f);
        }
    }

    IEnumerator AttackAnimation()
    {
        isAttacking = true;
        animator.SetBool("Attack", true);
        player.moveSpeed = 0;
        yield return new WaitForSeconds(0.35f);

        isAttacking = false;
        animator.SetBool("Attack", false);
        player.moveSpeed = 5;
    }
}
