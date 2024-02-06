using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    bool isMainSceneActive = true;

    void Update()
    {
        // Check for Enter key press to toggle scenes
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            ToggleScenes();
        }

        // Check for Escape key press to toggle scenes
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            SwitchToMainScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
    {
        
        #if UNITY_EDITOR
      
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        
        Application.Quit();
        #endif
    }
    }

    void ToggleScenes()
    {
        if (isMainSceneActive)
        {
            SwitchToLevel1();
        }
        else
        {
            SwitchToMainScene();
        }

        isMainSceneActive = !isMainSceneActive;
    }

    void SwitchToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    void SwitchToMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
