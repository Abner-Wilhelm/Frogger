using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsControlUI : MonoBehaviour
{
    bool isMainSceneActive = true;

    // Reference to the UI Button in the inspector
    public Button switchButton;

    void Start()
    {
        // Add a listener to the button so that the SwitchScenes method is called when the button is clicked
        switchButton.onClick.AddListener(ToggleScenes);
    }

    void ToggleScenes()
    {
        // Check the current scene before deciding which scene to load
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "MainScene")
        {
            SwitchToGameControlsUI();
        }
        else if (currentSceneName == "GameControlsUI")
        {
            SwitchToMainScene();
        }
    }

    void SwitchToGameControlsUI()
    {
        SceneManager.LoadScene("GameControlsUI");
    }

    void SwitchToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
