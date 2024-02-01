using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour

{
    public Texture2D cursorTexture; // Assign the cursor texture in the Inspector

    void Start()
    {
        // Set the cursor initially (you can change it later based on game events)
        SetCustomCursor();
    }

    public void SetCustomCursor()
    {
        // Set the custom cursor with hotspot at the center
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);
    }

    public void SetDefaultCursor()
    {
        // Set the default system cursor
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

