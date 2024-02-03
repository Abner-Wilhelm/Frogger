using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
// SoundManager.cs
{
    public static SoundManager instance;

    public AudioSource gameOverSound;  // Make sure to attach an AudioSource in the Inspector

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            gameOverSound.Play();
        }
        else
        {
            Debug.LogError("gameOverSound is not assigned in the Inspector.");
        }
    }
}
