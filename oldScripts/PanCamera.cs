using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanCamera : MonoBehaviour
{
    //Declaring the variables
    public float panSpeed = 40.0f;       // Speed of the camera when being panned
    public float zoomSpeed = 150.0f;      // Speed of the camera going back and forth

    private Vector3 mouseOrigin;    // Position of cursor when mouse dragging starts
    private Vector2 mouseOriginForScroll;    // Position of cursor when mouse dragging starts
    private bool isPanning;     // Is the camera being panned?
    private bool isZoomingIn;     // Is the camera zooming in?
    private bool isZoomingOut;     // Is the camera zooming out?

    //setting a range for both panning and zooming
    private float rangePanningX; // range for panning
    private float rangePanningZ; // range for panning
    private float rangeZooming; // Setting a range for zooming


    private CollisionFlags flags;

    //
    // UPDATE
    //

    void Update()
    {
        // Get the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Get the Scroll Wheel 
        if (Input.GetAxis("Mouse ScrollWheel") > 0) //back
        {
            // Get mouse origin
            mouseOriginForScroll = Input.mousePosition;
            isZoomingIn = true;
            Debug.Log("---Scrolling back---");
        }


        // Get the Scroll Wheel
        if (Input.GetAxis("Mouse ScrollWheel") < 0) //back
        {
            // Get mouse origin
            mouseOriginForScroll = Input.mousePosition;
            isZoomingOut = true;
            Debug.Log("---Scrolling forward---");
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(0)) isPanning = false;
        if (!(Input.GetAxis("Mouse ScrollWheel") > 0)) isZoomingIn = false;
        if (!(Input.GetAxis("Mouse ScrollWheel") < 0)) isZoomingOut = false;

        // Move the camera on it's XZ plane
        if (isPanning)
        {

            //rangePanningX = Mathf.Clamp(Camera.main.gameObject.transform.position.x, 652.0f, 1123.0f);
            //rangePanningZ = Mathf.Clamp(Camera.main.gameObject.transform.position.z, 1255.0f, 3452.0f);
            /*
            float cameraXPos = Camera.main.gameObject.transform.position.x;

            if (cameraXPos > 652.0f && cameraXPos < 1123.0f)
            {
                */
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(-pos.x * panSpeed, -pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);

            //Debug.Log("---cam pos_1---" + cameraXPos);


        /*}
            
            /*
            else if (cameraXPos <= 1123.0f )
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
                transform.Translate(move, Space.Self);

                Debug.Log("---panning__22---");
            }
            /*else if (cameraXPos >= 625.0f)
            {
                Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

                Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
                transform.Translate(move, Space.Self);

                Debug.Log("---panning__23---");
            }










            /*
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);

            Debug.Log("---panning---" + pos);
            /*
            Debug.Log("---panning x position---" + pos.x);
            Debug.Log("---panning y position---" + pos.y);
            Debug.Log("---Camera Position x position---" + Camera.main.gameObject.transform.position.x);
            Debug.Log("---Camera Position y position---" + Camera.main.gameObject.transform.position.y);
            Debug.Log("---Camera Position z position---" + Camera.main.gameObject.transform.position.z);
            Debug.Log("---Range Panning X---" + rangePanningX);
            Debug.Log("---Range Panning Z---" + rangePanningZ);
            */
        }

        // Move the camera linearly along Y axis
        if (isZoomingIn)
        {


            Vector2 pos = Camera.main.ScreenToViewportPoint(Input.mouseScrollDelta - mouseOriginForScroll);

            Vector3 move = new Vector3(0, pos.y * zoomSpeed, 0);

            transform.Translate(move, Space.World);

            Debug.Log("---Zooming in---" + pos.y);
        }

        // Move the camera linearly along Z axis
        if (isZoomingOut)
        {
            Vector2 pos = Camera.main.ScreenToViewportPoint(Input.mouseScrollDelta + mouseOriginForScroll);

            Vector3 move = new Vector3(0, pos.y * zoomSpeed, 0);

            transform.Translate(move, Space.World);

            Debug.Log("---Zooming out---" + pos.y);
        }
    }

}


