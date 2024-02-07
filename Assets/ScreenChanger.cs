using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        change_resolution();
    }
    public int resolution = 1080;
    void change_resolution()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(resolution==1080){resolution=520;}
            else{resolution=1080;}
            Screen.SetResolution(resolution,resolution,false);
        }
    }
}
