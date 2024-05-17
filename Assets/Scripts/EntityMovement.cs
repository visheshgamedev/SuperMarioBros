using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    [SerializeField] private float entityMoveSpeed = 2f;
    
    private Rigidbody2D entityRB;

    private void Awake()
    {
        entityRB = GetComponent<Rigidbody2D>();
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        entityRB.WakeUp();
    }

    private void OnDisable()
    {
        entityRB.velocity = Vector2.zero;
        entityRB.Sleep();
    }

    private void FixedUpdate()
    {
        entityRB.velocity = new Vector2(-1 * entityMoveSpeed, entityRB.velocity.y);
    }
}