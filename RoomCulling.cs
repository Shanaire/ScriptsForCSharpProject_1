using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCulling : MonoBehaviour
{
    /*
     * This script is going to control the Culling of the various rooms that is going to be specific for each camera during and after transition
     *  
     * */

    // Main Camera object and camera component
    [Tooltip("Main Camera in Scene")]
    public GameObject MainCam;
    private Camera MainCam_;
    private List<GameObject> RoomCol = new List<GameObject>(); // A list of Gameobject to collect the rooms.

    // Referencing the CameraManager to use the transition function
    private CameraManager CamMan;
    int CountListItems = 0; // Counting List items

    // SubSection Cameras
    public GameObject SubCamera_1;
    private Camera SubCam_1;
    public GameObject SubCamera_2;
    private Camera SubCam_2;
    public GameObject SubCamera_3;
    private Camera SubCam_3;

    public int CameraCount = 0;

    // Creating an array to hold all the objects that is going be culled per ground. 
    // The Cameras GameObject and Component needs to be also saved.
    public List<GameObject> Room1_CullingGroup = new List<GameObject>();
    private List<GameObject> Room1_cGroup = new List<GameObject>();
    public GameObject Room1_CamObj; // Camera for that particular room
    private Camera Room1_Cam = new Camera(); // Camera from the Camera Game Object

    public List<GameObject> Room2_CullingGroup = new List<GameObject>();
    private List<GameObject> Room2_cGroup = new List<GameObject>();
    public GameObject Room2_CamObj; // Camera for that particular room
    private Camera Room2_Cam = new Camera(); // Camera from the Camera Game Object

    public List<GameObject> Room3_CullingGroup = new List<GameObject>();
    private List<GameObject> Room3_cGroup = new List<GameObject>();
    public GameObject Room3_CamObj; // Camera for that particular room
    private Camera Room3_Cam = new Camera(); // Camera from the Camera Game Object

    public List<GameObject> Room4_CullingGroup = new List<GameObject>();
    private List<GameObject> Room4_cGroup = new List<GameObject>();
    public GameObject Room4_CamObj; // Camera for that particular room
    private Camera Room4_Cam = new Camera(); // Camera from the Camera Game Object

    public List<GameObject> Room5_CullingGroup = new List<GameObject>();
    private List<GameObject> Room5_cGroup = new List<GameObject>();
    public GameObject Room5_CamObj; // Camera for that particular room
    private Camera Room5_Cam = new Camera(); // Camera from the Camera Game Object

    public List<GameObject> Room6_CullingGroup = new List<GameObject>();
    private List<GameObject> Room6_cGroup = new List<GameObject>();
    public GameObject Room6_CamObj; // Camera for that particular room
    private Camera Room6_Cam = new Camera(); // Camera from the Camera Game Object

    public List<GameObject> Room7_CullingGroup = new List<GameObject>();
    private List<GameObject> Room7_cGroup = new List<GameObject>();
    public GameObject Room7_CamObj; // Camera for that particular room
    private Camera Room7_Cam = new Camera(); // Camera from the Camera Game Object



    // ALL OTHER OBJECTS OTHER THAN ROOMS IN THE SCENE
    public List<GameObject> Other_CullingGroup = new List<GameObject>();
    private List<GameObject> Other_cGroup = new List<GameObject>();

    private void Start()
    {
        ROOM1();
        ROOM2();
        ROOM3();
        ROOM4();
        ROOM5();
        ROOM6();
        ROOM7();

        OTHER();

        CamMan = this.gameObject.GetComponent<CameraManager>();
    }

    private void Update()
    {
        CamMan.RayCasting();

        MainCamFunc();

        Debug.Log(MainCam_.enabled);
        StateChanged();
    }

    void MainCamFunc()
    {
        MainCam_ = MainCam.gameObject.GetComponent<Camera>();
        SubCam_1 = SubCamera_1.gameObject.GetComponent<Camera>();
        SubCam_2 = SubCamera_2.gameObject.GetComponent<Camera>();
        SubCam_3 = SubCamera_3.gameObject.GetComponent<Camera>();

        if (MainCam_.enabled == true)
        {
            CameraCount = 1;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (SubCam_1.enabled == true)
        {
            CameraCount = 2;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (SubCam_2.enabled == true)
        {
            CameraCount = 3;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (SubCam_3.enabled == true)
        {
            CameraCount = 4;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room1_Cam.enabled == true)
        {
            CameraCount = 5;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room2_Cam.enabled == true)
        {
            CameraCount = 6;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room3_Cam.enabled == true)
        {
            CameraCount = 7;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room4_Cam.enabled == true)
        {
            CameraCount = 8;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room5_Cam.enabled == true)
        {
            CameraCount = 9;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room6_Cam.enabled == true)
        {
            CameraCount = 10;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room7_Cam.enabled == true)
        {
            CameraCount = 11;
            Debug.Log("CameraCount " + CameraCount);
        }
    }

    void ROOM1()
    {
        Room1_Cam = Room1_CamObj.gameObject.GetComponent<Camera>();

        foreach (GameObject item in Room1_CullingGroup)
        {
            Room1_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }

    void ROOM2()
    {
        Room2_Cam = Room2_CamObj.gameObject.GetComponent<Camera>();

        foreach (GameObject item in Room2_CullingGroup)
        {
            Room2_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }

    void ROOM3()
    {
        Room3_Cam = Room3_CamObj.gameObject.GetComponent<Camera>();

        foreach (GameObject item in Room3_CullingGroup)
        {
            Room3_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }

    void ROOM4()
    {
        Room4_Cam = Room4_CamObj.gameObject.GetComponent<Camera>();

        foreach (GameObject item in Room4_CullingGroup)
        {
            Room4_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }

    void ROOM5()
    {
        Room5_Cam = Room5_CamObj.gameObject.GetComponent<Camera>();

        foreach (GameObject item in Room5_CullingGroup)
        {
            Room5_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }

    void ROOM6()
    {
        Room6_Cam = Room6_CamObj.gameObject.GetComponent<Camera>();

        foreach (GameObject item in Room6_CullingGroup)
        {
            Room6_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }

    void ROOM7()
    {
        Room7_Cam = Room7_CamObj.gameObject.GetComponent<Camera>();

        foreach (GameObject item in Room7_CullingGroup)
        {
            Room7_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }

    void OTHER()
    {

        foreach (GameObject item in Other_CullingGroup)
        {
            Other_cGroup.Add(item);
            RoomCol.Add(item);
        }
    }


    void StateChanged()
    {

        if (CameraCount == 1)
        {
            CountListItems = 0;
            Debug.Log("Testing _1");

            // Looping through each iteration of RoomCol and adding 1 to the counter and setting the items to active, then when 
            //RoomCol == Counter, use transition camera function, to transition back to the main camera position 
            foreach (GameObject item in RoomCol)
            {
                item.SetActive(true);
                CountListItems += 1;

                Debug.Log("RoomCol.Count = " + RoomCol.Count);
                Debug.Log("CountListItems = " + CountListItems);

                if (CountListItems == RoomCol.Count)
                {
                    if (CamMan.TransitionCode == 10)
                    {
                        CamMan.CameraTransition();
                    }
                }

            }
        }
        // Subsection 1
        else if (CameraCount == 2)
        {
            Debug.Log("Testing _2");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(false);
            }

            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();
        }
        // Subsection 2
        else if (CameraCount == 3)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();

        }
        // Subsection 3
        else if (CameraCount == 4)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();

        }
        // Room1
        else if (CameraCount == 5)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();

        }
        // Room 2
        else if (CameraCount == 6)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }
            CamMan.CameraTransition();

        }
        // Room 3
        else if (CameraCount == 7)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }
            CamMan.CameraTransition();

        }
        // Room4
        else if (CameraCount == 8)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();
        }
        // Room5
        else if (CameraCount == 9)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();
        }
        // Room 6
        else if (CameraCount == 10)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();
        }
        // Room 7
        else if (CameraCount == 11)
        {
            Debug.Log("Testing _1");
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room3_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room4_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room5_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room6_cGroup)
            {
                item.SetActive(false);
            }
            foreach (GameObject item in Room7_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Other_cGroup)
            {
                item.SetActive(false);
            }

            CamMan.CameraTransition();

        }

    }

}
