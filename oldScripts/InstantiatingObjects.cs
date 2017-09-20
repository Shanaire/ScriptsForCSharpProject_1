using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatingObjects : MonoBehaviour
{

    //drag prefab here in editor
    public Transform InstantiateMe;

    // Creating a place holder for the object that are going to be created
    public GameObject Object_1;
    public GameObject Object_2;
    public GameObject Object_3;

    // Creating a place holder to hold the active object
    public GameObject CurrentObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Using the alpha numeric number on the keyboard to assign the objects to be create to the objects list
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Assigning an object to the current object
            CurrentObject = Object_1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentObject = Object_2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentObject = Object_3;
        }

        // Instantiate the current object into the scene through the use of ray casting and the left mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Defining the raycast
            RaycastHit hitpoint;

            int Range = 5000;

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
            /*
                        // Casting a ray to register a hit point with the raycast
                        if (hitpoint.transform.name == "Terrain")
                        {
                            Instantiate(CurrentObject, new Vector3(Mathf.RoundToInt(hitpoint.point.x), 0.5f, Mathf.RoundToInt(hitpoint.point.z)));
                        }
            */
        }


        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            you don't have to instantiate at the transform's positio nand rotation, swap these for what suits your needs
            var go = Instantiate(InstantiateMe, transform.position, transform.rotation);
        }
        */
    }
}
