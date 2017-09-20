using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullingGroups1 : MonoBehaviour
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
        Cam = Camera.GetComponent<Camera>();
        objT = obj[0].gameObject.GetComponent<Transform>();

        group = new CullingGroup();

        // Adding a foreach loop, which iterates through each element in the list of gameobjects "obj" and adds them to the culling list of game objects.
            foreach (GameObject item in obj)
            {
                Culling.Add(item);
            }
        //Culling.Add(obj[0]);
        //Culling[1] = obj[1];


        //spheres[0] = new BoundingSphere(new Vector3(0, 0.4f, 0), 5f);

        Debug.Log(Culling[0] + " Culling OBJ");

        group.onStateChanged = StateChangedMethod;
        group.SetBoundingSpheres(spheres);
        group.SetBoundingSphereCount(1);

        Debug.Log(spheres[0] + " Spheres");

        group.targetCamera = Cam;

        // group.IsVisible(0);
    }


    void Room1()
    {

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
    }



}
