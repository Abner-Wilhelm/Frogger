using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour

{
    // Attach this script to the button that will trigger the exit

    public void ExitGameButton()
    {
        // This will only work in a standalone build (not in the Unity Editor)
        // It's disabled in the editor for safety reasons
#if UNITY_STANDALONE
        Application.Quit();
#endif

        // In the Unity Editor or other platforms (like Android or iOS),
        // you might want to add other behavior (e.g., stop the play mode in the editor).
    }
}
