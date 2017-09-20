/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCulling1 : MonoBehaviour
{
    /*
     * This script is going to control the Culling of the various rooms that is going to be specific for each camera during and after transition
     *  
     * */

    // Specifying the culling groups for each rooms and Section areas
 //   CullingGroup Room1;
  //  CullingGroup Room2;

/*
    public GameObject MainCam;
    private Camera MainCam_;

  //  BoundingSphere[] Room1_BSpheres = new BoundingSphere[100];
  //  BoundingSphere[] Room2_BSpheres = new BoundingSphere[100];

    //
    int CameraCount = 0;

    // Creating an array to hold all the objects that is going be culled per ground. 
    // The Cameras GameObject and Component needs to be also saved.
    public List<GameObject> Room1_CullingGroup = new List<GameObject>();
    private List<GameObject> Room1_cGroup = new List<GameObject>();
    public GameObject Room1_Floor;
    private Transform Room1_FloorTransfrom;
    public GameObject Room1_CamObj; // Camera for that particular room
    private Camera Room1_Cam = new Camera(); // Camera from the Camera Game Object

    public List<GameObject> Room2_CullingGroup = new List<GameObject>();
    private List<GameObject> Room2_cGroup = new List<GameObject>();
    public GameObject Room2_Floor;
    private Transform Room2_FloorTransfrom;
    public GameObject Room2_CamObj; // Camera for that particular room
    private Camera Room2_Cam = new Camera(); // Camera from the Camera Game Object

    private void Update()
    {
   //     Room1_BSpheres[0] = new BoundingSphere(new Vector3(0, 0, 0), 10f);
    //    Room2_BSpheres[0] = new BoundingSphere(new Vector3(0, 0, 0), 10f);

        //        Room1.onStateChanged = StateChangedMethod;
        //        Room2.onStateChanged = StateChangedMethod;

        ROOM1();
        ROOM2();
        MainCamFunc();

        Debug.Log(MainCam_.enabled);
        StateChanged();
    }

    private void OnEnable()
    {
        //    ROOM1();
        //  ROOM2();
    }
    void MainCamFunc()
    {
        MainCam_ = MainCam.gameObject.GetComponent<Camera>();

        if (MainCam_.enabled == true)
        {
            CameraCount = 1;
            Debug.Log("CameraCount " + CameraCount);
        }
        else if (Room1_Cam.enabled == true)
        {
            CameraCount = 2;
            Debug.Log("CameraCount " + CameraCount);

        }
        else if (Room2_Cam.enabled == true)
        {
            CameraCount = 3;
            Debug.Log("CameraCount " + CameraCount);

        }


    }

    void ROOM1()
    {
        Room1_Cam = Room1_CamObj.gameObject.GetComponent<Camera>();
        Room1_FloorTransfrom = Room1_Floor.GetComponent<Transform>();

       // Room1 = new CullingGroup();

        foreach (GameObject item in Room1_CullingGroup)
        {
            Room1_cGroup.Add(item);
        }

        //Room1.onStateChanged = StateChangedMethod;
      //  Room1.SetBoundingSpheres(Room1_BSpheres);
     //   Room1.SetBoundingSphereCount(1);

      //  Room1.targetCamera = Room1_Cam;
    }

    void ROOM2()
    {
        Room2_Cam = Room2_CamObj.gameObject.GetComponent<Camera>();
        Room2_FloorTransfrom = Room2_Floor.GetComponent<Transform>();

   //     Room2 = new CullingGroup();

        foreach (GameObject item in Room2_CullingGroup)
        {
            Room2_cGroup.Add(item);
        }

        // Room2.onStateChanged = StateChangedMethod;
        //Room2.SetBoundingSpheres(Room1_BSpheres);
       // Room2.SetBoundingSphereCount(1);

     //   Room2.targetCamera = Room2_Cam;
    }




//    void OnDisable()
 //   {
 //       Room1.Dispose();
 //       Room1 = null;

  //      Room2.Dispose();
//        Room2 = null;
   // }

    void StateChanged()
    {

        if (CameraCount == 1)
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


        }
        else if (CameraCount == 2)
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
        }
        else if (CameraCount == 3)
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
        }

    }

}

*/