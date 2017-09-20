using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour {


    /*
     *disable the raycasting script when the panel is toggled on.
     **/

    public GameObject Button;

    bool condition = true || false;

    public cameraSwitcher1 Cam;

    public void TogglePanel()
    {

        if (condition == true)
        {
            Debug.Log("---STATUS TRUE---" + condition);
            Button.SetActive(true);
            Cam.Range = 0;
            condition = false;


        }
        else if (condition == false)
        {
            Debug.Log("---STATUS False---" + condition);
            Button.SetActive(false);
            Cam.Range = 500;
            condition = true;
        }
    }
}
