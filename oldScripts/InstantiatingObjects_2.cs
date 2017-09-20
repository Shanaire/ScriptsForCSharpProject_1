using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatingObjects_2 : MonoBehaviour
{

    //drag prefab here in editor
    public Transform InstantiateMe;

    // Creating a place holder to hold the active object
    public GameObject CurrentObject;

    public float Range = 5000f;

    // Update is called once per frame
    public void Update()
    {
        //RaycastHit testHit;



        //Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        // Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        //Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        //Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Debug.DrawRay(Input.mousePosition, Input.mousePosition, Color.green);

        //CreateObjects();
    }
    public void CreateObjects()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitpoint;
                
            // Setting the raycast from the camera to the centre of the screen ( THIS HOWEVER NEEDS TO BE FROM THE CAMERA TO THE MOUSE CLICK POSITION)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);       /*new Vector3(Screen.width / 2, Screen.height / 2, 0)); */

            if (Physics.Raycast(ray, out hitpoint, Range))
            {
                Debug.Log(hitpoint.transform + "hitpoint transform");
                Debug.Log(hitpoint.point + "hitpoint point");
                Debug.Log(hitpoint.point.x + "hitpoint point x");
                Debug.Log(hitpoint.point.y + "hitpoint point y");
                Debug.Log(hitpoint.point.z + "hitpoint point z");
                Debug.Log(hitpoint.distance + ("hitpoint distance"));
                Instantiate(CurrentObject, new Vector3(hitpoint.point.x, hitpoint.point.y, hitpoint.point.z), Quaternion.identity);
            }
        }
    }
}
