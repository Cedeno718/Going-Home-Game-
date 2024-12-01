using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;    // Speed of horizontal movement
    [SerializeField] float jumpSpeed = 5f;   // Force applied when jumping
    Vector2 moveInput;                       // Stores player input
    Rigidbody2D myRigidbody;                 // Reference to the Rigidbody2D
    Animator myAnimator;                     // Reference to the Animator
    CircleCollider2D myCircleCollider;       // Reference to the ground-check collider
    BoxCollider2D myFeetCollider;

    bool isAlive = true;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>(); 
        myCircleCollider = GetComponent<CircleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        Run();
        FlipSprite(); // Ensures the player faces the correct direction
        Die();



        // CheckIfJumping();
    }

    void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        // Capture horizontal movement input
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }
        // Only allow jumping if the player is on the ground
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (value.isPressed)
        {
            // Apply vertical velocity for jumping
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpSpeed);

            // Flip immediately if the player jumps with horizontal input
            if (Mathf.Abs(moveInput.x) > Mathf.Epsilon)
            {
                transform.localScale = new Vector2(Mathf.Sign(moveInput.x), 1f);
            }
        }
    }

    void Run()
    {
        // Set player velocity based on horizontal input and run speed
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        // Check if the player is moving horizontally
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalking", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        // Flip the sprite based on horizontal velocity
        if (Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }

     void Die()
    {
        if (myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
        }
    }
    void Capture()
    {
        if (myCircleCollider.IsTouchingLayers(LayerMask.GetMask("Enemies")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Capture");
        }
    }


    // void CheckIfJumping()
    // {
    //     // Check if the player is airborne by checking vertical velocity
    //     bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;

    //     // Update the "isJumping" animator parameter
    //     myAnimator.SetBool("isJumping", playerHasVerticalSpeed);
    // }
}
