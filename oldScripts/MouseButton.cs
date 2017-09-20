using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Mouse Pressed");
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right Mouse Pressed");
        }
        else if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("Middle Mouse");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) // back
        {
            //Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize - 1, 1); >> Scrolling camera
            Debug.Log("Scroll Wheel Back");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0) // forward
        {
            //Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize - 1, 6);
            Debug.Log("Mouse Wheel Scroll forward");
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Arrow Pressed");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down Arrow Pressed");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Arrow Pressed");
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Right Arrow Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Num 0 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Num 1 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Num 2 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Num 3 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Num 4 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Num 5 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Debug.Log("Num 6 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Debug.Log("Num 7 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Debug.Log("Num 8 Pressed");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Debug.Log("Num 9 Pressed");
        }

    }
}
