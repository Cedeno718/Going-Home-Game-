using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Pass the collider (other) to the coroutine
        StartCoroutine(LoadNextLevel(other));
    }

    IEnumerator LoadNextLevel(Collider2D other)
    {
        // Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            // Wait for the specified delay before loading the next level
            yield return new WaitForSecondsRealtime(levelLoadDelay);

            // Get the current scene index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Load the next scene (next room)
            SceneManager.LoadScene("Start Scene");
        }
    }
}
