using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRestart : MonoBehaviour

{
    // Reference to the UI Button in the inspector
    public Button switchToMainSceneButton;

    void Start()
    {
        // Add a listener to the button to switch scenes when clicked
        switchToMainSceneButton.onClick.AddListener(SwitchToMainScene);
    }

    void SwitchToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
