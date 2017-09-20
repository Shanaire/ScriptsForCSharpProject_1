using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    /* 
     * This script is to change room to a particular camera when the button is press.
     * The Camera needs to be activated before the panel is diabled
     * When the button is pressed, the current panel needs to be deactivate i.e, turned off.
     * 
     */

    //____________________________________REFERENCED FILES_____________________________________//
    public GameObject CamSetup;
    private CameraManager CamMan_1;

    //Setting Connection to true when the function is ran
    private DeactivatePan ConditionTog;
    public GameObject FloorPlanPanel;
    //_________________________________________________________________________________________//



    public void Start()
    {
        CamMan_1 = CamSetup.GetComponent<CameraManager>();
        ConditionTog = FloorPlanPanel.GetComponent<DeactivatePan>();
    }

    public void ChangeToRoom()
    {
        if (tag == "Room1")
        {
            // Add an if statement for each of the separate rooms
            CamMan_1.CameraCount = 11;
            FloorPlanPanel.SetActive(false);

            Debug.Log("Change Room Test");

            ConditionTog.condition = false;
        }
        else if (tag == "Room2")
        {
            // Add an if statement for each of the separate rooms
            CamMan_1.CameraCount = 12;
            FloorPlanPanel.SetActive(false);

            Debug.Log("Change Room Test");

            ConditionTog.condition = false;
        }
        else if (tag == "Room3")
        {
            // Add an if statement for each of the separate rooms
            CamMan_1.CameraCount = 13;
            FloorPlanPanel.SetActive(false);

            Debug.Log("Change Room Test");

            ConditionTog.condition = false;
        }
    }


}
