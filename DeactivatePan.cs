using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivatePan : MonoBehaviour
{
    /* 
     * This script is used to control the activation and the deactivation of the floor plan pop for that is used to transition to different rooms.
     * 
     */

    //_______________________________REFERENCED FILES__________________________________//



    //_________________________________________________________________________________//
    // Referencing the centre panels
    public List<GameObject> cPanels = new List<GameObject>();

    // This is the GameObject of the map panel.
    public GameObject Panel_1;

    public bool condition = false || true;

    public void OnorOff()
    {
        if (condition == true && Panel_1.activeSelf == false)
        {
            Panel_1.SetActive(true);
            condition = true;

            //Debug.Log("___WORKING___");

        }
        else if (condition == true && (cPanels[0].activeSelf == true || cPanels[1].activeSelf == true || cPanels[2].activeSelf == true || cPanels[3].activeSelf == true))
        {
            Panel_1.SetActive(false);
            condition = true;
            Debug.Log("____WORKING____");
        }
        else
        {
            if (condition == false)
            {
                Debug.Log("---CHANGING STATUS---" + condition);

                Panel_1.SetActive(true);
                condition = true;


            }
            else if (condition == true)
            {
                Debug.Log("---CHANGING STATUS---" + condition);

                Panel_1.SetActive(false);
                condition = false;
            }
        }
    }
}

