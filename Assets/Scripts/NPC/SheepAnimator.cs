using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepAnimator : MonoBehaviour
{
    public float MoveX { get; set; }
    public float MoveY { get; set; }
    public bool IsMoving { get; set; }

    private Animator animator;

    public bool left;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (left)
        {
            animator.SetFloat("moveX", -1f);
        }
    }

    void Update()
    {

        if (IsMoving)
        {
            animator.SetBool("Walking", true);
        }
        else
        {
            animator.SetBool("Walking", false);
        }

        

        SetMovementAnimations();
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
    }
}
