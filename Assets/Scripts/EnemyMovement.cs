using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float chaseSpeed = 1f;         // Speed of the enemy while chasing
    [SerializeField] float detectionRange = 10f;   // Distance to detect the player
    [SerializeField] float chaseDelay = 1f;        // Time before the enemy starts chasing

    public GameObject player;
    public bool isChasing = false;                // Tracks if the enemy is actively chasing
    public bool isPreparingToChase = false;       // Tracks if the enemy is waiting to start chasing
    private Rigidbody2D playerRigidbody;          // Reference to the player's Rigidbody2D

    void Start()
    {
        // Find the player by tag
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerRigidbody = player.GetComponent<Rigidbody2D>(); // Get the player's Rigidbody2D
        }
    }

    void Update()
    {
        if (player == null) return; // If the player doesn't exist, do nothing

        // Calculate the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // If the player is within range, has started moving, and the enemy is not already chasing or preparing to chase
        if (distanceToPlayer <= detectionRange && PlayerHasStartedMoving() && !isChasing && !isPreparingToChase)
        {
            StartCoroutine(StartChaseAfterDelay());
        }

        // If chasing, continue following the player
        if (isChasing)
        {
            Chase();
        }
    }

    private bool PlayerHasStartedMoving()
    {
        if (playerRigidbody == null) return false;

        // Check if the player's velocity exceeds a small threshold
        return Mathf.Abs(playerRigidbody.velocity.x) > 0.1f || Mathf.Abs(playerRigidbody.velocity.y) > 0.1f;
    }

    private IEnumerator StartChaseAfterDelay()
    {
        isPreparingToChase = true; // The enemy is preparing to chase
        yield return new WaitForSeconds(chaseDelay); // Wait for the specified delay
        isChasing = true;          // Start chasing
        isPreparingToChase = false; // No longer preparing
    }

    private void Chase()
    {
        // Move towards the player in 2D space
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);

        // Flip the enemy's facing direction based on movement
        FlipEnemyFacing(player.transform.position.x - transform.position.x);
    }

    private void FlipEnemyFacing(float direction)
    {
        // Flip the sprite to face the player
        if (direction > 0 && transform.localScale.x < 0 || direction < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}



