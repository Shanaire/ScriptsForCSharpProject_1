using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolForCentrePanels : MonoBehaviour
{
    /*
     * This file is to be the boolean control for the central panels and another other items that will be linked to this file
     * 
     */

    // Gameobjects of the panels that are going to be toggled on and off
    // public GameObject centrePanel;

    // The Boolean toggle for these panels
    public bool panelCondition = false;

    private void Update()
    {
        _panelCondition();

    }

    public void _panelCondition()
    {
        panelCondition = false;
        if (panelCondition == true)
        {
            panelCondition = true;
            // This is just to control the TRUE state of the function
        }
        else if (panelCondition == false)
        {
            panelCondition = false;
            // This is just to control the FALSE state of the function
        }
    }
}
