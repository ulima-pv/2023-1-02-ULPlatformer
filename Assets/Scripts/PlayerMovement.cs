using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 4f;

    private Vector2 mMoveInput;
    private Rigidbody2D mRb;
    private Animator mAnimator;

    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        mRb.velocity = new Vector2(
            mMoveInput.x * runSpeed,
            mRb.velocity.y
        );

        if (Mathf.Abs(mRb.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector3(
                Mathf.Sign(mRb.velocity.x),
                transform.localScale.y,
                transform.localScale.z
            );
            // Idle -> Running
            mAnimator.SetBool("IsRunning", true);
        }else {
            mAnimator.SetBool("IsRunning", false);
        }
        
    }

    private void OnMove(InputValue value)
    {
        mMoveInput = value.Get<Vector2>();

    }
}
