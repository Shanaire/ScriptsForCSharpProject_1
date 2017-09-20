using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartToggle : MonoBehaviour
{
    /* 
     * This Script is to launch the main appb interface or reveal it while rte
     * 
     * [Might also need to disable the raycasting script in this file before the main interface becomes active]
     * 
     * 
     */

    //_____________________________________REFERENCE FILES_________________________________//

    public GameObject FloorPanel;
    private DeactivatePan DeactivatePanel;
    //_____________________________________________________________________________________//1
    
    public GameObject StartInterface;
    public GameObject ScreenInterface;

    private void Start()
    {
        //DeactivatePanel = FloorPanel.gameObject.GetComponent<DeactivatePan>();
    }

    public void UILaunch()
    {
        StartInterface.SetActive(true);
        ScreenInterface.SetActive(false);
    }


}
