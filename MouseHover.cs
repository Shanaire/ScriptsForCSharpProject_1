using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    /*
     *
     * Using this script allows for the object this script is attached to to become highlighted by a specific color speficifed
     * 
     * And when the mouse it removed this color returns to white or another which is speficied
     * 
     * The idea is to store the initial color before the color is actually changed
     * Then once it is stored the color is then change to the specified highlighted color.
     * After which when the mouse is removed the stored color would become the object color going back to its original color.
     * 
     * Currently doing this doesn't work, not sure why
     * 
     **/


    //_________________________________________REFERENCED FILES_____________________________//
    public GameObject CameraManagerObject;
    private CameraManager _CameraManagerObject;

    public List<GameObject> cPanel_2 = new List<GameObject>();

    //______________________________________________________________________________________//

    // Initialising the Colours that are going to be used
    private Renderer render;
    private Color InitialColor;
    private Color Selected;
    float h, s, v;

    private float r, g, b, a;
    // Use this for initialization
    void Start()
    {
        render = GetComponent<Renderer>();
        render.enabled = true;

        _CameraManagerObject = CameraManagerObject.gameObject.GetComponent<CameraManager>();
    }

    private void OnMouseEnter()
    {
        /*
         * This is where the inital color of the object will be stored
         * */

        // When this centre panel is active i.e true, this is when the mouse hover needs to be disabled. Therefore this is disabling the mouse hover.
        if (cPanel_2[0].activeSelf == true || cPanel_2[1].activeSelf == true || cPanel_2[2].activeSelf == true || cPanel_2[3].activeSelf == true)
        {
            InitialColor = render.material.color;
            Selected = InitialColor;
        }
        else
        {
            // SubSection 1

            // Room 1
            if ((tag == "Room1"))
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room1")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        InitialColor = SubSection1Rooms.material.color;
                        Color.RGBToHSV(InitialColor, out h, out s, out v);

                        v = 1.5f;
                        if (v == 0)
                        { v = 1.5f; }

                        Selected = Color.HSVToRGB(h, s, v);
                        Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                        Debug.Log("Section 1 Hover");
                    }
                }
                else
                {
                    InitialColor = render.material.color;
                    Color.RGBToHSV(InitialColor, out h, out s, out v);

                    v = 1.5f;
                    if (v == 0)
                    { v = 1.5f; }

                    Selected = Color.HSVToRGB(h, s, v);
                    Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                    Debug.Log("Section 1 Hover");
                }
            }
            // Room 2
            if ((tag == "Room2"))
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room2")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        InitialColor = SubSection1Rooms.material.color;
                        Color.RGBToHSV(InitialColor, out h, out s, out v);

                        v = 1.5f;
                        if (v == 0)
                        { v = 1.5f; }

                        Selected = Color.HSVToRGB(h, s, v);
                        Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                        Debug.Log("Section 1 Hover");
                    }
                }
                else
                {
                    InitialColor = render.material.color;
                    Color.RGBToHSV(InitialColor, out h, out s, out v);

                    v = 1.5f;
                    if (v == 0)
                    { v = 1.5f; }

                    Selected = Color.HSVToRGB(h, s, v);
                    Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                    Debug.Log("Section 1 Hover");
                }
            }
            // Room 3
            if ((tag == "Room3"))
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room3")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        InitialColor = SubSection1Rooms.material.color;
                        Color.RGBToHSV(InitialColor, out h, out s, out v);

                        v = 1.5f;
                        if (v == 0)
                        { v = 1.5f; }

                        Selected = Color.HSVToRGB(h, s, v);
                        Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                        Debug.Log("Section 1 Hover");
                    }
                }
                else
                {
                    InitialColor = render.material.color;
                    Color.RGBToHSV(InitialColor, out h, out s, out v);

                    v = 1.5f;
                    if (v == 0)
                    { v = 1.5f; }

                    Selected = Color.HSVToRGB(h, s, v);
                    Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                    Debug.Log("Section 1 Hover");
                }
            }

            // SubSection 2
            else if ((tag == "Room4") || (tag == "Room5") || (tag == "Room6"))
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room4"),
                        GameObject.FindGameObjectWithTag("Room5"),
                        GameObject.FindGameObjectWithTag("Room6")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        InitialColor = SubSection1Rooms.material.color;
                        Color.RGBToHSV(InitialColor, out h, out s, out v);

                        v = 1.5f;
                        if (v == 0)
                        { v = 1.5f; }

                        Selected = Color.HSVToRGB(h, s, v);
                        Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                        Debug.Log("Section 1 Hover");
                    }
                }
                else
                {
                    InitialColor = render.material.color;
                    Color.RGBToHSV(InitialColor, out h, out s, out v);

                    v = 1.5f;
                    if (v == 0)
                    { v = 1.5f; }

                    Selected = Color.HSVToRGB(h, s, v);
                    Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                    Debug.Log("Section 1 Hover");
                }
            }

            // Subsection 3
            else if (tag == "Room7")
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room7")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        InitialColor = SubSection1Rooms.material.color;
                        Color.RGBToHSV(InitialColor, out h, out s, out v);

                        v = 1.5f;
                        if (v == 0)
                        { v = 1.5f; }

                        Selected = Color.HSVToRGB(h, s, v);
                        Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                        Debug.Log("Section 1 Hover");
                    }
                }
                else
                {
                    InitialColor = render.material.color;
                    Color.RGBToHSV(InitialColor, out h, out s, out v);

                    v = 1.5f;
                    if (v == 0)
                    { v = 1.5f; }

                    Selected = Color.HSVToRGB(h, s, v);
                    Debug.LogFormat("Starting Render Color OVR {0}", InitialColor);
                    Debug.Log("Section 1 Hover");
                }
            }
        }
    }

    public void OnMouseOver()
    {
        if ((_CameraManagerObject.CameraCount != 11) && (_CameraManagerObject.CameraCount != 12) &&
            (_CameraManagerObject.CameraCount != 13) && (_CameraManagerObject.CameraCount != 14) &&
            (_CameraManagerObject.CameraCount != 15) && (_CameraManagerObject.CameraCount != 16) &&
            (_CameraManagerObject.CameraCount != 17))
        {

            // SubSection 1
            // Room 1
            if ((tag == "Room1"))
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room1")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        SubSection1Rooms.material.color = Selected;
                        if (Input.GetMouseButtonDown(0))
                        {
                            SubSection1Rooms.material.color = InitialColor;
                        }
                    }
                }
                else
                {
                    render.material.color = Selected;
                }
            }
            // Room 2
            if ((tag == "Room2"))
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room2")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        SubSection1Rooms.material.color = Selected;
                        if (Input.GetMouseButtonDown(0))
                        {
                            SubSection1Rooms.material.color = InitialColor;
                        }
                    }
                }
                else
                {
                    render.material.color = Selected;
                }
            }
            // Room 3
            if ((tag == "Room3"))
            {
                if (_CameraManagerObject.CameraCount != 1)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room3")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        SubSection1Rooms.material.color = Selected;
                        if (Input.GetMouseButtonDown(0))
                        {
                            SubSection1Rooms.material.color = InitialColor;
                        }
                    }
                }
                else
                {
                    render.material.color = Selected;
                }
            }

            // SubSection 2
            else if ((tag == "Room4") || (tag == "Room5") || (tag == "Room6"))
            {
                if (_CameraManagerObject.CameraCount != 2)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room4"),
                        GameObject.FindGameObjectWithTag("Room5"),
                        GameObject.FindGameObjectWithTag("Room6")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        SubSection1Rooms.material.color = Selected;
                        if (Input.GetMouseButtonDown(0))
                        {
                            SubSection1Rooms.material.color = InitialColor;
                        }
                    }
                }
                else
                {
                    render.material.color = Selected;
                }
            }

            // Subsection 3
            else if (tag == "Room7")
            {
                if (_CameraManagerObject.CameraCount != 3)
                {
                    List<GameObject> RoomFloor = new List<GameObject>
                    {
                        // Finding all object with the respective tag and add then to a list
                        GameObject.FindGameObjectWithTag("Room7")
                    };

                    // Now i'm gonna interate through the list of gameobjects added to the list and change their colors
                    foreach (GameObject item in RoomFloor)
                    {
                        Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                        SubSection1Rooms.material.color = Selected;
                        if (Input.GetMouseButtonDown(0))
                        {
                            SubSection1Rooms.material.color = InitialColor;
                        }
                    }
                }
                else
                {
                    render.material.color = Selected;
                }
            }
        }
        // Removing the Highlighted colour effect when at at a single room level to disable the highlighting
        else
        {
            // By making this function true, it is going to be used to disable the raycast function.
            _CameraManagerObject.DeactPan_FloorPlan_Panels.condition = true;

            // SubSection 1
            if ((tag == "Room1") || (tag == "Room2") || (tag == "Room3"))
            {
                render.material.color = InitialColor;
            }

            // SubSection 2
            else if ((tag == "Room4") || (tag == "Room5") || (tag == "Room6"))
            {
                render.material.color = InitialColor;
            }

            // Subsection 3
            else if (tag == "Room7")
            {
                render.material.color = InitialColor;
            }
        }
    }

    private void OnMouseExit()
    {
        // SubSection 1
        // Room 1
        if ((tag == "Room1"))
        {
            if (_CameraManagerObject.CameraCount != 1)
            {
                List<GameObject> RoomFloor = new List<GameObject>
                {
                    // Finding all object with the respective tag and add then to a list
                    GameObject.FindGameObjectWithTag("Room1")
                };

                Debug.Log("Adding OBJ" + RoomFloor);
                // Now i'm gonna interate through the list of gameobjects added to the list and change their colors

                foreach (GameObject item in RoomFloor)
                {
                    Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                    SubSection1Rooms.material.color = InitialColor;
                }
            }
            else
            {
                render.material.color = InitialColor;
            }
        }
        // Room 2
        if ((tag == "Room2"))
        {
            if (_CameraManagerObject.CameraCount != 1)
            {
                List<GameObject> RoomFloor = new List<GameObject>
                {
                    // Finding all object with the respective tag and add then to a list
                    GameObject.FindGameObjectWithTag("Room2")

                };

                Debug.Log("Adding OBJ" + RoomFloor);
                // Now i'm gonna interate through the list of gameobjects added to the list and change their colors

                foreach (GameObject item in RoomFloor)
                {
                    Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                    SubSection1Rooms.material.color = InitialColor;
                }
            }
            else
            {
                render.material.color = InitialColor;
            }
        }
        // Room 3
        if ((tag == "Room3"))
        {
            if (_CameraManagerObject.CameraCount != 1)
            {
                List<GameObject> RoomFloor = new List<GameObject>
                {
                    // Finding all object with the respective tag and add then to a list
                    GameObject.FindGameObjectWithTag("Room3")
                };

                Debug.Log("Adding OBJ" + RoomFloor);
                // Now i'm gonna interate through the list of gameobjects added to the list and change their colors

                foreach (GameObject item in RoomFloor)
                {
                    Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                    SubSection1Rooms.material.color = InitialColor;
                }
            }
            else
            {
                render.material.color = InitialColor;
            }
        }

        // Subsection 2
        else if ((tag == "Room4") || (tag == "Room5") || (tag == "Room6"))
        {
            if (_CameraManagerObject.CameraCount != 1)
            {
                List<GameObject> RoomFloor = new List<GameObject>
                {
                    // Finding all object with the respective tag and add then to a list
                    GameObject.FindGameObjectWithTag("Room4"),
                    GameObject.FindGameObjectWithTag("Room5"),
                    GameObject.FindGameObjectWithTag("Room6")
                };

                Debug.Log("Adding OBJ" + RoomFloor);
                // Now i'm gonna interate through the list of gameobjects added to the list and change their colors

                foreach (GameObject item in RoomFloor)
                {
                    Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                    SubSection1Rooms.material.color = InitialColor;
                }
            }
            else
            {
                render.material.color = InitialColor;
            }
        }

        // Subsection 3
        else if (tag == "Room7")
        {
            if (_CameraManagerObject.CameraCount != 1)
            {
                List<GameObject> RoomFloor = new List<GameObject>
                {
                    // Finding all object with the respective tag and add then to a list
                    GameObject.FindGameObjectWithTag("Room7")
                };

                Debug.Log("Adding OBJ" + RoomFloor);
                // Now i'm gonna interate through the list of gameobjects added to the list and change their colors

                foreach (GameObject item in RoomFloor)
                {
                    Renderer SubSection1Rooms = item.GetComponent<Renderer>();
                    SubSection1Rooms.material.color = InitialColor;
                }
            }
            else
            {
                render.material.color = InitialColor;
            }
        }
    }
}
