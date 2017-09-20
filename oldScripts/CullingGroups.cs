using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingGroups : MonoBehaviour
{

    BoundingSphere[] spheres = new BoundingSphere[1000];

    CullingGroup group;

    public List<GameObject> obj = new List<GameObject>();
    private List<GameObject> Culling = new List<GameObject>();
    private Transform objT;

    public GameObject Camera;
    private Camera Cam = new Camera();


    private void Update()
    {
        spheres[0] = new BoundingSphere(new Vector3(objT.transform.position.x, objT.transform.position.y, objT.transform.position.z), 5f);
    }

    private void OnEnable()
    {
        Room1();


    }


    void Room1()
    {
        Cam = Camera.GetComponent<Camera>();
        objT = obj[0].gameObject.GetComponent<Transform>();

        group = new CullingGroup();

        foreach (GameObject item in obj)
        {
            Culling.Add(item);
        }

        group.onStateChanged = StateChangedMethod;
        group.SetBoundingSpheres(spheres);
        group.SetBoundingSphereCount(1);

        group.targetCamera = Cam;

    }


    private void OnDisable()
    {
        group.Dispose();
        group = null;
    }

    private void StateChangedMethod(CullingGroupEvent evt)
    {

        if (evt.hasBecomeVisible)
        {
            Debug.Log(group.IsVisible(0) + " Checking vis");
            foreach (GameObject item in Culling)
            {
                item.SetActive(false);
            }
        }
        else if (evt.hasBecomeInvisible)
        {
            Debug.Log(group.IsVisible(0) + " Checking vis");
            foreach (GameObject item in Culling)
            {
                item.SetActive(true);
            }
        }

        /*
            else if (Room2_Cam.enabled == true && Room1_Cam.enabled == false && MainCam_.enabled == false)
            {
                Debug.Log("Testing _2");
                foreach (GameObject item in Room1_cGroup)
                {
                    item.SetActive(false);
                }
                foreach (GameObject item in Room2_cGroup)
                {
                    item.SetActive(true);
                }
            } 
             if (Room2_Cam.enabled) && Room1_Cam.enabled == false && Room2_Cam.enabled == false
            {
                Debug.Log("Testing _3");
//                foreach (GameObject item in Room1_cGroup)
//                {
//                    item.SetActive(false);
//                }
//                foreach (GameObject item in Room2_cGroup)
//               {
//                  item.SetActive(false);
//             }
            }
        }


        else if (evt.hasBecomeInvisible)
        {
            foreach (GameObject item in Room1_cGroup)
            {
                item.SetActive(true);
            }
            foreach (GameObject item in Room2_cGroup)
            {
                item.SetActive(true);
            }
        } */

    }



}
