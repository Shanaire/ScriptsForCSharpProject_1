using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraManTest : MonoBehaviour
{
    /* 
     * This is a test script that is testing the fading aspect of the transition between cameras.
     * 
     * [CAMERA TRANSITION]
     * [CAMERA SWITCHING]
     * [RAY CASTING]
     * 
     * [CAMERA FADING BETWEEN CAMERAS]
     * 
     * */


    //-------------------------------REFERENCED SCRIPTS-----------------------------------------//
    public GameObject Panel_FloorPlans;
    public DeactivatePan DeactPan_FloorPlans;
    //__________________________________________________________________________________________//

    // Camera and initial camera empty position
    public GameObject MainCam; public GameObject MainCam_INS;
    public Transform InitialCamPosition;
    // Camera Component Reference
    private Camera ActiveCamera;
    private Transform CurrentTransform;

    public int CameraCount = 0;
    public int TransitionCode = 0;

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

    private void Start()
    {
        ActiveCamera = MainCam.GetComponent<Camera>();

        CurrentTransform = MainCam.GetComponent<Transform>();
    }

    public void Update()
    {
        Debug.Log(" Main Cam = " + MainCam);
        RayCasting();
    }

    private void LateUpdate()
    {
        CameraSwitching();
        //CameraTransition();
    }

    public void CameraTransition()
    {
        // Transitioning to SubCam 1
        if (TransitionCode == 1)
        {
            CurrentTransform = TransitionPointsToSub[0];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);
            //MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, currentView.transform.position, 20f * Time.deltaTime);
        }

        // Trasititioning to SubCam 2
        else if (TransitionCode == 2)
        {
            CurrentTransform = TransitionPointsToSub[1];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);
        }

        // Transititioning to SubCam 3
        else if (TransitionCode == 3)
        {
            CurrentTransform = TransitionPointsToSub[2];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);



        }

        //__________________________TRANSITIONING TO SUBSECTION 1 ROOMS__________________________// 
        // Transitioning to Room1
        else if (TransitionCode == 11)
        {
            CurrentTransform = TransitionPointsToRoom[0];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);

        }
        // Transitioning to Room2
        else if (TransitionCode == 12)
        {
            CurrentTransform = TransitionPointsToRoom[1];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);

        }
        // Transitioning to Room3
        else if (TransitionCode == 13)
        {
            CurrentTransform = TransitionPointsToRoom[2];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);
        }
        //__________________________TRANSITIONING TO SUBSECTION 2 ROOMS__________________________// 
        // Transitioning to Room4
        else if (TransitionCode == 14)
        {
            CurrentTransform = TransitionPointsToRoom[3];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);

        }
        // Transitioning to Room5
        else if (TransitionCode == 15)
        {
            CurrentTransform = TransitionPointsToRoom[4];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);

        }
        // Transitioning to Room6
        else if (TransitionCode == 16)
        {
            CurrentTransform = TransitionPointsToRoom[5];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);
        }
        //__________________________TRANSITIONING TO SUBSECTION 3 ROOMS__________________________// 
        // Transitioning to Room7
        else if (TransitionCode == 17)
        {
            CurrentTransform = TransitionPointsToRoom[6];
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);

        }

        //__________________________TRANSITIONING TO MAIN CAMERA INITIAL POTITION__________________________// 
        // Transition back to main camera initial position
        else if (TransitionCode == 10)
        {
            Debug.Log("Testing Trans 10");

            Debug.Log(MainCam.gameObject.transform.position);

            CurrentTransform = InitialCamPosition;
            MainCam.transform.position = Vector3.Lerp(MainCam.gameObject.transform.position, CurrentTransform.transform.position, Time.deltaTime * TransitionSpeed);
            //MainCam.transform.position = Vector3.MoveTowards(MainCam.transform.position, currentView.transform.position, 1f * Time.deltaTime);
        }

    }

    public void CameraSwitching()
    {
        // Sub Cameras being added to a private group getting there Transform properties
        SubCam_.Add(SubCams[0].gameObject.GetComponent<Transform>());
        SubCam_.Add(SubCams[1].gameObject.GetComponent<Transform>());
        SubCam_.Add(SubCams[2].gameObject.GetComponent<Transform>());

        //Room Cameras to switch to, getting there transform properties
        RoomCam_.Add(RoomCams[0].gameObject.GetComponent<Transform>());
        RoomCam_.Add(RoomCams[1].gameObject.GetComponent<Transform>());
        RoomCam_.Add(RoomCams[2].gameObject.GetComponent<Transform>());



        //Vector3 pos1 = (ActiveCamera.transform.rotation.eulerAngles + new Vector3(0.0f, 0.1f, 0.0f));
        //Vector3 pos2 = currentView.transform.rotation.eulerAngles;

        //Debug.Log("checking pos " + Tpos1 + Tpos2);

        if (CameraCount == 1)
        {
            SubCam_[0].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = SubCams[0];

            if (MainCam == SubCams[0])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 1;
            }

        }
        else if (CameraCount == 2)
        {
            SubCam_[1].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = SubCams[1];

            if (MainCam == SubCams[1])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 2;
            }
        }
        else if (CameraCount == 3)
        {
            SubCam_[2].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = SubCams[2];

            if (MainCam == SubCams[2])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 3;

            }
        }
        /*_____________________________SubSection 1 Rooms__________________________________________*/
        // Individual Room 1 Cameras, switching cameras 
        if (CameraCount == 11)
        {
            RoomCam_[0].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = RoomCams[0];

            if (MainCam == RoomCams[0])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 11;
            }
        }
        // Individual Room 2 Cameras, switching cameras 
        else if (CameraCount == 12)
        {
            RoomCam_[1].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = RoomCams[1];

            if (MainCam == RoomCams[1])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 12;
            }
        }
        // Individual Room 3 Cameras, switching cameras
        else if (CameraCount == 13)
        {
            RoomCam_[2].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = RoomCams[2];

            if (MainCam == RoomCams[2])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 13;
            }
        }
        /*__________________________________SubSection 2 Rooms______________________________________*/
        // Individual Room 4 Cameras, switching cameras
        else if (CameraCount == 14)
        {
            RoomCam_[3].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = RoomCams[3];

            if (MainCam == RoomCams[3])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 14;
            }
        }
        // Individual Room 5 Cameras, switching cameras
        else if (CameraCount == 15)
        {
            RoomCam_[4].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = RoomCams[4];

            if (MainCam == RoomCams[4])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 15;
            }
        }
        // Individual Room 6 Cameras, switching cameras
        else if (CameraCount == 16)
        {
            RoomCam_[5].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = RoomCams[5];

            if (MainCam == RoomCams[5])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 16;
            }
        }
        /*__________________________________SubSection 3 Rooms______________________________________*/
        // Individual Room 7 Cameras, switching cameras
        else if (CameraCount == 17)
        {
            RoomCam_[6].transform.position = new Vector3(MainCam.transform.position.x, MainCam.transform.position.y, MainCam.transform.position.z);

            // Deactivating the Current Camera
            ActiveCamera.enabled = false;

            // Switching the Current Camera to a Sub Camera
            MainCam = RoomCams[6];

            if (MainCam == RoomCams[6])
            {
                // Then re-assign MainCam Camera component to the new MainCam, which is the switched camera and then Set it to Active
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                // Number to activate the point transition
                TransitionCode = 17;
            }
        }

        // Moving Back to the initial position
        else if (CameraCount == 10)
        {
            MainCam_INS.transform.position = new Vector3(CurrentTransform.transform.position.x, CurrentTransform.transform.position.y, CurrentTransform.transform.position.z);

            ActiveCamera.enabled = false;

            //Debug.Log(MainCam + " MainCam");
            MainCam = MainCam_INS;

            if (MainCam == MainCam_INS)
            {
                ActiveCamera = MainCam.GetComponent<Camera>();
                ActiveCamera.enabled = true;

                TransitionCode = 10;
            }

        }
    }

    public void RayCasting()
    {
        Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ActiveCamera.farClipPlane);
        Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, ActiveCamera.nearClipPlane);

        Vector3 mousePosF = ActiveCamera.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = ActiveCamera.ScreenToWorldPoint(mousePosNear);

        RaycastHit hit;
        Ray RayToObject = new Ray(mousePosN, mousePosF);

        DeactPan_FloorPlans = Panel_FloorPlans.GetComponent<DeactivatePan>();

        if (Input.GetMouseButton(0))
        {
            Debug.DrawRay(mousePosN, mousePosF, Color.green);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (DeactPan_FloorPlans.condition == true)
            {
                Physics.Raycast(RayToObject, 0f);
                Debug.Log("Checking");
            }

            else if (DeactPan_FloorPlans.condition == false)
            {
                {


                    if (Physics.Raycast(RayToObject, out hit))
                    {
                        // Casting a Ray for SubSection 1 and changing the Camera Count
                        // This is not using section 1 anymore just moving straight to the Rooms
                        /*
                        if ((hit.collider.transform.tag == "Room1") || (hit.collider.transform.tag == "Room2") || (hit.collider.transform.tag == "Room3"))
                        {

                            if (CameraCount == 11)
                            {

                            }
                            else
                                CameraCount = 1;
                        }
                        */

                        // Casting a Ray for SubSection 2 and changing the Camera Count
                        if ((hit.collider.transform.tag == "Room4") || (hit.collider.transform.tag == "Room5") || (hit.collider.transform.tag == "Room6"))
                        {
                            CameraCount = 2;
                        }

                        // Castingf a Ray for SubSection 3 and changing the Camera Count
                        if (hit.collider.tag == "Room7")
                        {
                            CameraCount = 3;
                        }

                        // Casting a Ray for the individual Room1 etc given the relevant sub camera is activated

                        // Room 1
                        if ((hit.collider.transform.tag == "Room1"))
                        {

                            Debug.Log("pos");
                            CameraCount = 11;
                        }

                        // Room 2
                        if ((hit.collider.transform.tag == "Room2"))
                        {

                            Debug.Log("pos");
                            CameraCount = 12;

                        }

                        // Room 3
                        if ((hit.collider.transform.tag == "Room1"))
                        {

                            Debug.Log("pos");
                            CameraCount = 13;

                        }

                        // Subsection 2 changing to one of the room cameras
                        else if (CameraCount == 2)
                        {
                            // Room 4
                            if (MainCam == SubCams[1])
                            {
                                if (hit.collider.transform.tag == "Room4")
                                {
                                    CameraCount = 14;
                                }
                            }

                            // Room 5
                            if (MainCam == SubCams[1])
                            {
                                if (hit.collider.transform.tag == "Room5")
                                {
                                    CameraCount = 15;
                                }
                            }

                            // Room 6
                            if (MainCam == SubCams[1])
                            {
                                if (hit.collider.transform.tag == "Room6")
                                {
                                    CameraCount = 16;
                                }
                            }
                        }
                        // Subsection 3 changing to one of the room cameras
                        else if (CameraCount == 3)
                        {
                            // Room 7
                            if (MainCam == SubCams[2])
                            {
                                if (hit.collider.transform.tag == "Room7")
                                {
                                    CameraCount = 17;
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Nothing Clicked");
                    }
                }
            }
        }
    }

    // This is going to be a revse transition back to the main camera's initial position
    public void ReverseTransition()
    {
        // Set the current transition point to the transition position of the main camera's
        CameraCount = 10;

        // Setting this bool condition back to false to enable raycasting from this script
        DeactPan_FloorPlans.condition = false;
        Debug.Log("Reverse");
        //currentView = InitialCamPosition;
    }


}

