using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnClick : MonoBehaviour
{
    public GameObject Create;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public void CreateObject()
    {
        /*if (Input.GetMouseButtonDown(0))
        {*/
  ///      Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
  ///      Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

  //      Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
   //     Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

  //      Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);

       // RaycastHit hit;
        
        /*
        //Ray casting
        RaycastHit hit;

        if
            { 
        Vector3 mousePos = Input.mousePosition;
        


        mousePos.z = 2.0f;

        var objectPos = Camera.main.ScreenToWorldPoint(mousePos);

        Instantiate(Create, mousePosF - mousePosN, Quaternion.identity);
        */
        
    }
}
