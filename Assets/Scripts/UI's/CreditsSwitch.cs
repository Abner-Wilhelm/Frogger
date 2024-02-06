using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreditsSwitch : MonoBehaviour
{
    // Reference to the UI Button in the inspector
    public Button switchToCreditsButton;

    void Start()
    {
        // Add a listener to the button so that the SwitchToCredits method is called when the button is clicked
        switchToCreditsButton.onClick.AddListener(SwitchToCredits);
    }

    void SwitchToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
