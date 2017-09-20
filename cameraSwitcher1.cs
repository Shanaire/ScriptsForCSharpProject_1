using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitcher1 : MonoBehaviour
{
    public Camera Main;
    public Camera NewCam;

    public float Range = 500F;
    public Transform[] TransitionPos;
    public float transitionSpeed;
    Transform currentView;
    /*
        private void Start()
        {
            Main = GetComponent<Camera>();
        }

    */

    public void Update()
    {
        LookingForObject();

        // Debug.Log("TESTING " + (Main.transform.rotation.eulerAngles.y));
        // Debug.Log("TESTING_2 " + currentView.transform.rotation.eulerAngles.y);

    }


    public void LateUpdate()
    {
        Transition();

        CameraSwitching();
    }

    public void Transition()
    {
        //Lerp > linear interpolation
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
             Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));
        transform.eulerAngles = currentAngle;
    }


    public void CameraSwitching()
    {

        Vector3 pos1 = (Main.transform.rotation.eulerAngles + new Vector3(0.0f, 0.1f, 0.0f));

        Vector3 pos2 = currentView.transform.rotation.eulerAngles;

        Debug.Log("checking pos " + pos1 + pos2);

        // Switching Cameras
        if (currentView == TransitionPos[0])
        {
            if (pos1.y > pos2.y)
            {
                Main.enabled = false;
                NewCam.enabled = true;
            }
        }
        else if (currentView == TransitionPos[1])
        {
            Main.enabled = true;
            NewCam.enabled = false;
        }

    }


    public void LookingForObject()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        RaycastHit hit;

        Ray RayToObject = new Ray(mousePosN, mousePosF);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(mousePosN, mousePosF * Range, Color.green);
            Physics.Raycast(RayToObject, out hit, Range);

            if (hit.collider != null && hit.collider.tag == "HIT")
            {
                currentView = TransitionPos[0];
                Debug.Log("Hit");
            }
            else
            {
                Debug.Log("Nothing Found");

            }
        }
    }

    public void ReverseCamera()
    {
        currentView = TransitionPos[1];
    }



}