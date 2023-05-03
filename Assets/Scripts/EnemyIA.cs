using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float rayDistance = 2f;

    private Rigidbody2D mRb;
    private CapsuleCollider2D mCollider;
    
    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        mRb.velocity = new Vector2(speed, mRb.velocity.y);
        if (PodriaCaer())
        {
            Debug.Log("Podria caer");
            // Cambiar de direccion
            speed *= -1;
        }

        if (mCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            GameManager.Instance.PlayerDamage();
        }
    }

    private bool PodriaCaer()
    {
        // 1. Lanzar el cast (rayo)
        var hit = Physics2D.Raycast(
            transform.position,
            new Vector2(
                mRb.velocity.x < 0f ? -1 : 1,
                -1f
            ).normalized,
            rayDistance,
            LayerMask.GetMask("Ground")
        );

        if (hit) 
        {
            Debug.DrawRay(
                transform.position,
                new Vector2(
                    mRb.velocity.x < 0f ? -1 : 1,
                    -1f
                ).normalized * rayDistance,
                Color.red
            );
            return false;
        }
        else 
        {
            Debug.DrawRay(
                transform.position,
                new Vector2(
                    mRb.velocity.x < 0f ? -1 : 1,
                    -1f
                ).normalized * rayDistance,
                Color.green
            );
            return true;
        }
    }
}
