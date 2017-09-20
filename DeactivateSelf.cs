using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateSelf : MonoBehaviour
{

    public GameObject Button;


    //private int set = 0; // using this set variable to toggle through the different if statements

    private bool condition = true || false;


    public void Update()
    {

    }

    public void TogglePanel()
    {

        if (condition == true)
        {
            Debug.Log("---STATUS TRUE---" + condition);

            Button.SetActive(true);
            condition = false;
        }
        else if (condition == false)
        {
            Debug.Log("---STATUS False---" + condition);
            Button.SetActive(false);
            condition = true;
        }
    }

}





