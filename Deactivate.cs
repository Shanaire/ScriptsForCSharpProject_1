using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{

    public GameObject Button;
    public GameObject Title;

    public List<GameObject> Panels = new List<GameObject> ();
    public List<GameObject> TitleDeAct = new List<GameObject>();
    
    //public GameObject Panel_1;
    //public GameObject Panel_2;
    //public GameObject Panel_3;
    //public GameObject Panel_4;


    //private int set = 0; // using this set variable to toggle through the different if statements

    private bool condition = true || false;


    public void TogglePanel()
    {
   
        

        if (condition == false)
        {
            Debug.Log("---CHANGING STATUS---" + condition);

            Button.SetActive(false);
            Title.SetActive(false);
            condition = true;
        }
        else if (condition == true)
        {
            Debug.Log("---CHANGING STATUS---" + condition);

            Button.SetActive(true);
            Title.SetActive(true);

            // Setting all gameobjects in the list to inactive
            foreach (GameObject item in Panels)
               item.SetActive(false);

            foreach (GameObject item in TitleDeAct)
                item.SetActive(false);

            condition = false;
        }
    }
}






