using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPanelManager : MonoBehaviour
{
    /* 
     * This script is to be used to activate the button panels for each room corresponding to the room camera that is active 
     */

    //____________________________________________REFERENCED FILES_______________________________//

    // Referencing the Camera Manager
    public GameObject CamMan;
    private CameraManager _CamMan;
    //___________________________________________________________________________________________//

    // Assining the different Room panels to a list
    public List<GameObject> RoomPanels = new List<GameObject>();

    private void Start()
    {
        _CamMan = CamMan.gameObject.GetComponent<CameraManager>();
    }

    private void Update()
    {
        PanelCondition();
    }


    void PanelCondition()
    {
        // either the main or sub cameras are active, then the panels will be switched off or false.
        if ((_CamMan.CameraCount == 1) || (_CamMan.CameraCount == 2) || (_CamMan.CameraCount == 3) || (_CamMan.CameraCount == 10))
        {
            foreach (GameObject item in RoomPanels)
            {
                item.SetActive(false);
            }
        }
        //__________ACTIVATING THE PANELS FOR THE ROOMS___________//
        // Room1
        else if (_CamMan.CameraCount == 11)
        {
            RoomPanels[0].SetActive(true);

        }
        // Room2
        else if (_CamMan.CameraCount == 12)
        {
            RoomPanels[1].SetActive(true);
        }
        // Room3
        else if (_CamMan.CameraCount == 13)
        {
            RoomPanels[2].SetActive(true);
        }
        // Room4
        else if (_CamMan.CameraCount == 14)
        {
            RoomPanels[3].SetActive(true);
        }
        // Room5
        else if (_CamMan.CameraCount == 15)
        {
            RoomPanels[4].SetActive(true);
        }
        // Room6
        else if (_CamMan.CameraCount == 16)
        {
            RoomPanels[5].SetActive(true);
        }
        // Room7
        else if (_CamMan.CameraCount == 17)
        {
            RoomPanels[6].SetActive(true);
        }

    }



}
