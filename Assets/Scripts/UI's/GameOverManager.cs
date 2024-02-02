using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameOverManager.cs
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        // You may need to replace "SoundManager" with the actual name of your SoundManager GameObject
        SoundManager.instance.PlayGameOverSound();
    }
}
