using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCentrePanelControl : MonoBehaviour
{
    /* 
     * This Script is to control the use the buttons on the side to trigger the on or off condition of the centre panels.
     * 
     * When this panel is active, the raycasting function needs to be deactivated.
     *  ->> This can be done using the condition that the floorplan used buy settign the [DeactivatePan] condition to true 
     *  ->> So the [DeactivatePan] script needs to be referenced in mimicing the previous use of the referenced function
     * 
     */


    //__________________________________REFERENCED FILES_________________________________//
    // The actual panel objects
    public GameObject cPanel;
    // Boolean for the panel objects
    public BoolForCentrePanels _cPanelBool; // true meanse 0 raycast, false means do raycast

    // Referencing the script to disable the raycasting on the floor

    //___________________________________________________________________________________//

    // A light of panel that are going be deactivated
    public List<GameObject> cPanel_Deactivate = new List<GameObject>();

    public void CPanelToggle()
    {
        // This cPanel is if the gameObject is active, rather than the script
        if (cPanel.activeSelf == true)
        {
            Debug.Log("---CHANGING STATUS---" + _cPanelBool.panelCondition);

            cPanel.gameObject.SetActive(false);
            _cPanelBool.panelCondition = false;

        }
        else if (_cPanelBool.panelCondition == false)
        {
            Debug.Log("---CHANGING STATUS---" + _cPanelBool.panelCondition);

            cPanel.gameObject.SetActive(true);

            // Setting all gameobjects in the list to inactive
            foreach (GameObject item in cPanel_Deactivate)
                item.SetActive(false);

            _cPanelBool.panelCondition = true;
        }
    }
}







