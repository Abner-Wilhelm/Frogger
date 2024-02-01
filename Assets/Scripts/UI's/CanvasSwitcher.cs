using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas gameCanvas;
    public Canvas uiCanvas;

    Canvas currentCanvas;

    void Start()
    {
        // Ensure that the initial state is set correctly
        SwitchToUICanvas();
    }

    void Update()
    {
        // Check for Enter key press to switch to gameCanvas
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SwitchToGameCanvas();
        }

        // Check for Escape key press to switch back to uiCanvas
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToUICanvas();
        }
    }

    void SwitchToGameCanvas()
    {
        SwitchCanvas(gameCanvas);
    }

    void SwitchToUICanvas()
    {
        SwitchCanvas(uiCanvas);
    }

    void SwitchCanvas(Canvas targetCanvas)
    {
        if (currentCanvas != null)
        {
            currentCanvas.gameObject.SetActive(false);
        }

        targetCanvas.gameObject.SetActive(true);
        currentCanvas = targetCanvas;
    }
}
