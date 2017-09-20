using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTestScript : MonoBehaviour {

    // Changing the initial colour
    private Color InitialColor = new Color();
    private Color Selected = new Color();
 

    private Renderer Mat = new Renderer();
    float h, s, v; // HSV Color Mode

    // Changing the Texture Color

    private void Start()
    {
        Mat = GetComponent<Renderer>();
        Mat.enabled = true;

    }
    private void OnMouseEnter()
    {
        if (tag == "HIT")
        {
            InitialColor = Mat.material.color;

            Color.RGBToHSV(InitialColor, out h, out s, out v);

            s = s/2f;

            if (s == 0)
            {
                s = 55/255f;
            }

            Selected = Color.HSVToRGB(h, s, v);

            Debug.Log(Mat.material.color + " MouseEnter ");
            Debug.Log(InitialColor + " MouseEnter ");


        }
    }

    private void OnMouseOver()
    {
        if (tag == "HIT")
        {

            Mat.material.color = Selected;
            //Mat.material.SetColor("_Color", Selected);

            Debug.Log(Mat.material.color + " MouseOver ");
            Debug.Log(InitialColor + " MouseOver ");


        }
    }

    private void OnMouseExit()
    {
        if (tag == "HIT")
        {
            Mat.material.color = InitialColor;
            Debug.Log(Mat.material.color + " MouseExit ");
            Debug.Log(InitialColor + " MouseExit ");
        }
    }
}
