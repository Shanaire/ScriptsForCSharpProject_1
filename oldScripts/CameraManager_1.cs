using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager_1 : MonoBehaviour
{
    /* 
     * Then work out how to switch the camera from the current one back to the previous camera.
     * 
     * The next step now is to reverse the transition when the back button is pressed, with this whoever, the camera goes back to the main cameras initial position, 
     * and change the active camera back to the main camera
     * 
     * Currently this script can transition to different camera position then after a specific condition is meet, it will then swap to a different camera.
     * 
     * This script is to be used to control the camera behaviour in the scene
     * 
     * It will be used to control, which cameras needs to be turned on or off depending on the whats needs to be scene.
     * 
     * It will also control the transition interpolation between the different cameras.
     * 
     * It will also need to control the firing of the raycast from the current selected camera
     * 
     *          */

/*
    // Camera and initial camera empty position
    public GameObject MainCam; public GameObject MainCam_INS;
    public Transform InitialCamPosition;
    // Camera Component Reference
    private Camera ActiveCamera;
    private Transform currentView;

    int CameraCount = 0;

    // Sub Section Cameras to deactive
    public List<GameObject> SubCams = new List<GameObject>();
    private List<Transform> SubCam_ = new List<Transform>();
    public List<Transform> TransitionPointsToSub = new List<Transform>();
    //public List<Camera> CamerasToDeactivateSubCams = new List<Camera>();

    // Room cameras to deactivte
    public List<GameObject> RoomCams = new List<GameObject>();
    private List<Transform> RoomCam_ = new List<Transform>();
    public List<Transform> TransitionPointsToRoom = new List<Transform>();
    // public List<Camera> CamerasToDeactivateRoomCams = new List<Camera>();

    public float TransitionSpeed = 2.0f;

    // private GameObject hoverObject;

    private void Start()
    {
        ActiveCamera = MainCam.GetComponent<Camera>();
        currentView = MainCam.GetComponent<Transform>();
    }

    public void Update()
    {
        RayCasting();
    }

    private void LateUpdate()
    {
        // CameraTransition();
        CameraSwitching();
    }

    public void CameraTransition()
    {
        // Linear Interpolation
        MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, currentView.transform.position, Time.deltaTime * TransitionSpeed);

        // This is looking at a linear interpolated rotation
        /*
        Vector3 currentAngle = new Vector3(
            Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * TransitionSpeed),
            Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * TransitionSpeed),
             Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * TransitionSpeed));
        
        transform.eulerAngles = currentAngle;
        */ /*
    }

    public void CameraSwitching()
    {
        SubCam_.Add(SubCams[0].gameObject.GetComponent<Transform>());
        SubCam_.Add(SubCams[1].gameObject.GetComponent<Transform>());
        SubCam_.Add(SubCams[2].gameObject.GetComponent<Transform>());
/*
        Debug.Log(SubCam_[0] + " SubCam_");
        Debug.Log(SubCam_[1] + " SubCam_");
        Debug.Log(SubCam_[2] + " SubCam_");

        Debug.Log(SubCams[0] + " SubCams");
        Debug.Log(SubCams[1] + " SubCams");
        Debug.Log(SubCams[2] + " SubCams");
*/ /*

        //Vector3 pos1 = (ActiveCamera.transform.rotation.eulerAngles + new Vector3(0.0f, 0.1f, 0.0f));

        //Vector3 pos2 = currentView.transform.rotation.eulerAngles;

        //Vector3 Tpos1 = MainCam.transform.position + new Vector3(0.0f, -0.2f, 0.0f);

        //Vector3 Tpos2 = currentView.transform.position;

        //Debug.Log("checking pos " + Tpos1 + Tpos2);

        if (CameraCount == 1)
        {
            SubCam_[0].transform.position = new Vector3 (MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            //Debug.Log(ActiveCamera + " ActiveCamera");
            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = SubCams[0];
            Debug.Log(MainCam + " MainCam");

            //Debug.Log(SubCam_[0].transform.position + " SubCam[0] Pos");
            Debug.Log(" MainCam= " + MainCam + " SubCams[0]= " + SubCams[0]);

            // If the MainCam == SubCam i.e, its true,
            if (MainCam == SubCams[0])
            {
                // Then re-assign MainCam Camera component to the new MainCam and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;
            }

            /*




            //Debug.Log(ActiveCamera + " ActiveCam" + MainCam + " MainCam");
            if (MainCam == SubCams[0])
            {
                //Debug.Log("Testing");
                //Debug.Log(MainCam + " MainCam_1");



                //Debug.Log(MainCam + " Act-Main");
                //Debug.Log(ActiveCamera + " ActiveCamera_1");

            }

        */ /*
        }
        else if (CameraCount == 2)
        {

            //Debug.Log(ActiveCamera + " ActiveCamera");
            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            //Debug.Log(MainCam + " MainCam");
            // Switching the Current Camera to a Sub Camera
            MainCam = SubCams[1];

            //Debug.Log(ActiveCamera + " ActiveCam" + MainCam + " MainCam");
            // If the MainCam == SubCam i.e, its true,
            if (MainCam == SubCams[1])
            {
                //Debug.Log("Testing");
                //Debug.Log(MainCam + " MainCam_1");

                // Then re-assign MainCam Camera component to the new MainCam and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                //Debug.Log(MainCam + " Act-Main");
                //Debug.Log(ActiveCamera + " ActiveCamera_1");

            }

        }
        else if (CameraCount == 3)
        {
            //Debug.Log(ActiveCamera + " ActiveCamera");
            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            //Debug.Log(MainCam + " MainCam");
            // Switching the Current Camera to a Sub Camera
            MainCam = SubCams[2];

            //Debug.Log(ActiveCamera + " ActiveCam" + MainCam + " MainCam");
            // If the MainCam == SubCam i.e, its true,
            if (MainCam == SubCams[2])
            {
                //Debug.Log("Testing");
                //Debug.Log(MainCam + " MainCam_1");

                // Then re-assign MainCam Camera component to the new MainCam and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                //Debug.Log(MainCam + " Act-Main");
                //Debug.Log(ActiveCamera + " ActiveCamera_1");

            }

        }
        else if (currentView == InitialCamPosition)
        {
            //Debug.Log(ActiveCamera + " ActiveCamera");
            ActiveCamera.enabled = false;

            //Debug.Log(MainCam + " MainCam");

            MainCam = MainCam_INS;

            Debug.Log(MainCam + " MainCam " + MainCam_INS + " MainCam_2 ");

            //Debug.Log(ActiveCamera + " ActiveCam" + MainCam + " MainCam");


            if (MainCam == MainCam_INS)
            {
                //Debug.Log("Testing");
                //Debug.Log(MainCam + " MainCam_1");

                ActiveCamera = MainCam_INS.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                //Debug.Log(MainCam + " Act-Main");
                //Debug.Log(ActiveCamera + " ActiveCamera_1");

            }

        }

        /*
        // Switching Cameras
        if (currentView == TransitionPointsToSub[0])
        {
            if (pos1.y > pos2.y)
            {
                ActiveCamera.enabled = false;
                CamerasToDeactivateSubCams[0].enabled = true;
            }
        }
        else if (currentView == TransitionPointsToSub[1])
        {
            ActiveCamera.enabled = true;
            CamerasToDeactivateSubCams[0].enabled = false;
        }
        */ /*
    }

    public void RayCasting()
    {
        //Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        //Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ActiveCamera.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ActiveCamera.nearClipPlane);


        //Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        //Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        Vector3 mousePosF = ActiveCamera.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = ActiveCamera.ScreenToWorldPoint(mousePosNear);

        RaycastHit hit;

        Ray RayToObject = new Ray(mousePosN, mousePosF);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(currentView + " Checking CurrentView before");
            Debug.DrawRay(mousePosN, mousePosF, Color.green);

            Physics.Raycast(RayToObject, out hit);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name + "NAME");
                Debug.Log(hit.collider.tag + " TAG");
            }
            if (hit.collider.transform.tag == "SubSection1")
            {
                CameraCount = 1;
                //currentView = TransitionPointsToSub[0];
                Debug.Log("SubSection1");
            }
            else if (hit.collider.tag == "SubSection2")
            {
                CameraCount = 2;
                //currentView = TransitionPointsToSub[1];
                Debug.Log("SubSection2");
            }
            else if (hit.collider.tag == "SubSection3")
            {
                CameraCount = 3;
                //currentView = TransitionPointsToSub[2];
                Debug.Log("SubSection3");
            }
        }
    }

    // This is going to be a revse transition back to the main camera's initial position
    public void ReverseTransition()
    {
        // Set the current transition point to the transition position of the main camera's
        if (gameObject == null)
        {
            return;
        }
        else
        {
            currentView = InitialCamPosition;
        }

    }


    

    // This is going to be a function that is going to make the MainCameras position the same as the active cameras position then switch from the active camera to the main camera
    // Which will happen before the reverse trasition function runs.



    /*
    public void RayCastingHover()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        RaycastHit hit;

        Ray RayToObject = new Ray(mousePosN, mousePosF);
        if (Physics.Raycast(RayToObject, out hit))
        {
            Debug.DrawRay(mousePosN, mousePosF, Color.green);

            GameObject hitObject = hit.transform.gameObject;

            //hit.transform.root.gameObject;
            //HoverObject(hitObject);

            if (hit.collider != null)
            {
               // Debug.Log(hit.collider.gameObject.name + "NAME");
                //Debug.Log(hit.collider.tag + " TAG");

            }

            // Hit Collider for SubSection1 for switching camera
            if (hit.collider != null && hit.collider.tag == "SubSection1")
            {
                ActiveCamera = CamerasToDeactivateSubCams[0];
               Debug.Log("SubSection1");
            }

            // Hit Collider for SubSection2 for switching camera
            else if (hit.collider != null && hit.collider.tag == "SubSection2")
            {
                ActiveCamera = CamerasToDeactivateSubCams[0];
               // Debug.Log("SubSection2");
            }
        }


    }

    */


    /*
        private void ClearHoverObject()
        {
            if (hoverObject == null)
                return;

            // Returning the hover back to normal after moving mouse

            Debug.Log("TESTING");
            Renderer[] renders = hoverObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer item in renders)
            {
                Material material = item.material;
                material.color = Color.white;
                item.material = material;
            }

            hoverObject = null;

        }

        private void HoverObject(GameObject obj)
        {
            if (hoverObject != null)
            {
                if (obj == hoverObject)
                    return;
                ClearHoverObject();
            }

            hoverObject = obj;

            // Hovering Over SubSection1
            if (hoverObject.gameObject.tag == "SubSection1")
            {
                Renderer[] renders = hoverObject.GetComponentsInChildren<Renderer>();

                Debug.Log("Checking Hover");

                foreach (Renderer item in renders)
                {
                    Material material = item.material;
                    material.color = Color.green;
                    item.material = material;

                }
            }

        }
        */
}

