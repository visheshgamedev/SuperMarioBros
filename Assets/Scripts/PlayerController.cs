using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 8.0f;
    [SerializeField] private float playerJumpForce = 10.0f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D playerRB;
    private float inputHorizontalAxis;

    private bool isPlayerGrounded = true;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckGrounded();

        inputHorizontalAxis = Input.GetAxis("Horizontal");
        
        if(inputHorizontalAxis < 0f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        else if(inputHorizontalAxis > 0f)
        {
            transform.rotation = Quaternion.identity;
        }

        if (Input.GetButtonDown("Jump") && isPlayerGrounded)
        {
            playerRB.velocity = new Vector2(0, playerJumpForce);
        }
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(inputHorizontalAxis * playerSpeed, playerRB.velocity.y);
    }

    private void CheckGrounded()
    {
        RaycastHit2D rayCastGroundHit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, groundLayer);
        isPlayerGrounded = rayCastGroundHit.collider != null;
    }
}