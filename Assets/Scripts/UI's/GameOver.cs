using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenu;

    void Start()
    {
        // Hide the game over menu at the beginning
        gameOverMenu.SetActive(false);
    }

    public void ShowGameOverMenu()
    {
        // Show the game over menu
        gameOverMenu.SetActive(true);
    }

    public void RestartGame()
    {
        // Reload the current scene (restart the game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainScene()
    {
        // Load the main menu scene (adjust the scene name accordingly)
        SceneManager.LoadScene("MainScene");
    }
}
