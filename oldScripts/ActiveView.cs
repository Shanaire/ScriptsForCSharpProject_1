using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveView : MonoBehaviour
{


    public Camera ActiveCam;

    public List<GameObject> ToDeAct = new List<GameObject>();
    public List<GameObject> ToAct = new List<GameObject>();
    public List<Camera> ToDeAct_Cam = new List<Camera>();

    public GameObject Switch;
    private cameraSwitcher1 Cam;

    public void Update()
    {
        Cam = Switch.GetComponent <cameraSwitcher1>();
    }

    public void Activate()
    {
        ActiveCam.enabled = true;

        foreach (GameObject item in ToDeAct)
        {
            item.SetActive(false);
        }
        foreach (GameObject item in ToAct)
        {
            item.SetActive(true);
        }
        foreach (Camera item in ToDeAct_Cam)
        {
            item.enabled = false;
        }

        Cam.Range = 500;


    }


}
