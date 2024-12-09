using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this for SceneManager

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // Get the current scene index
        SceneManager.LoadScene(currentSceneIndex + 1); // Load the next scene
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application
        Debug.Log("Game Quit!"); // This works in the editor to confirm the function is called
    }
    public void HelpGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Help Scene");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Start Scene");
    }
}

