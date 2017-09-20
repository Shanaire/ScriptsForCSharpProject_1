using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptActivation : MonoBehaviour
{

    public GameObject scriptToDeactivate;
    public GameObject TextPan;
    public GameObject TextPlace;

    private bool condition = true;

    // Update is called once per frame
    void Update()
    {
        //GetComponents<>();


    }

    public void Activation()
    {
        if (condition == true)
        {
            scriptToDeactivate.GetComponent<PanCamera>().enabled = false;
            TextPan.gameObject.SetActive(false);
            TextPlace.gameObject.SetActive(true);
            condition = false;
            Debug.Log("---Set to false---" + condition);

        }
        else if (condition == false)
        {
            scriptToDeactivate.GetComponent<PanCamera>().enabled = true;
            TextPan.gameObject.SetActive(true);
            TextPlace.gameObject.SetActive(false);
            condition = true;
            Debug.Log("---Set to True---" + condition);
        }
    }
}
