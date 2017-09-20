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
    public GameObject cPanel;
    private BoolForCentrePanels _cPanelBool;

    public GameObject FloorplanPanel;
    private DeactivatePan _DeactivatePan;

    public List<GameObject> FloorsToHighlight = new List<GameObject>();

    //___________________________________________________________________________________//

    // This button shou
    //public GameObject cPanel_Active;

    // A light of panel that are going be deactivated
    public List<GameObject> cPanel_Deactivate = new List<GameObject>();

    private void Start()
    {
        _cPanelBool = cPanel.gameObject.GetComponent<BoolForCentrePanels>();
        _DeactivatePan = FloorplanPanel.gameObject.GetComponent<DeactivatePan>();
    }



    public void CPanelToggle()
    {
        if (cPanel.activeSelf == true && FloorplanPanel.activeSelf != false)
        {
            _cPanelBool.panelCondition = true;

            Debug.Log("__WORKING__");
        }
        else
        {
            if (_cPanelBool.panelCondition == false)
            {
                Debug.Log("---CHANGING STATUS---" + _cPanelBool.panelCondition);


                _DeactivatePan.condition = false;
                cPanel.gameObject.SetActive(false);
                _cPanelBool.panelCondition = true;
            }
            else if (_cPanelBool.panelCondition == true)
            {
                Debug.Log("---CHANGING STATUS---" + _cPanelBool.panelCondition);

                _DeactivatePan.condition = true;
                cPanel.gameObject.SetActive(true);

                // Setting all gameobjects in the list to inactive
                foreach (GameObject item in cPanel_Deactivate)
                    item.SetActive(false);

                _cPanelBool.panelCondition = false;
            }
        }
    }
}






