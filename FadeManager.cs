using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    /* 
     * This script is a manager script that is to be used to control the fading in and out of the different rooms, depending on which rooms are actually selected.
     * 
     * This script will work by storing a reference of the initial material properties of the object, then changing the material to a transparent one, with the alapha,
     * of the albedo being set to 0 and the value of the specular being set to zero. With this values at this value the object will be transparent.
     * 
     * When transitioning to the previous view, the objects woukld reverse the process with the initially stored values.
     * 
     * {Testing out the use of iTween for the ransition animation}
     */

    //___________________________________________REFERENCED FILES______________________________________________//



    //_________________________________________________________________________________________________________//

    // First we need to reference in instances of the different rooms and their renders.
    public List<GameObject> RoomsToFade = new List<GameObject>(); // Solid Objects
    public List<GameObject> RoomsTranspToFade = new List<GameObject>(); // Solid Objects

    // Room Counter
    public int RoomCounter = 0;

    // Accessing the material states of the materials
    public List<Material> RoomTransMats_1 = new List<Material>(); // Transparent Materials of the Rooms 
    public List<Material> RoomMats_1 = new List<Material>(); // List of Room 1 Mats
    public Renderer[] rend_1; // Renderer for Room 1 solid objects
    public Renderer[] rend_1_1; // Renderers for Room 1 Trnasparent objects

    public List<Material> RoomTransMats_2 = new List<Material>(); // Transparent Materials of the Rooms
    public List<Material> RoomMats_2 = new List<Material>(); // List of Room 2 Mats 
    public Renderer[] rend_2; // Renderer for Room 2
    public Renderer[] rend_2_1; // Renderers for Room 1 Trnasparent objects

    private void Start()
    {
        //_________________ROOM1____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_1 = RoomsToFade[0].GetComponentsInChildren<Renderer>();
        rend_1_1 = RoomsTranspToFade[0].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_1.Add(item_2);
            }
        }
        foreach (Renderer item in rend_1_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_1.Add(item_2);
            }
        }


        //__________________ROOM2_____________________//
        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_2 = RoomsToFade[1].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_2)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_2.Add(item_2);
            }
        }
    }

    private void Update()
    {
        // Making Room 1 Transparent
        if (Input.GetKeyDown(KeyCode.S))
        {
            RoomCounter = 1;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[0], 0, 1);
            iTween.FadeTo(RoomsTranspToFade[0], 0, 1);
        }
        // Returning Room 1 to its normal state
        if (Input.GetKeyDown(KeyCode.X))
        {
            RoomCounter = 1;
            iTween.FadeTo(RoomsToFade[0], 1, 2);
            Invoke("ReturnToNormal", 2f);
        }


        // Making Room 2 Transparent 
        if (Input.GetKeyDown(KeyCode.A))
        {
            RoomCounter = 2;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[1], 0, 1);
        }
        // Returning Room 1 to its normal state
        if (Input.GetKeyDown(KeyCode.Z))
        {
            RoomCounter = 2;
            iTween.FadeTo(RoomsToFade[1], 1, 2);
            Invoke("ReturnToNormal", 2f);
        }

    }

    // Function to change the objects initial material to transparent
    private void ChangeToTransparent()
    {
        // Fading Room1 when the trigger button is pressed
        if (RoomCounter == 1)
        {
            foreach (Material item in RoomMats_1)
            {
                Debug.Log("Testing ---------->>>");

                item.SetFloat("_Mode", 2);
                item.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                item.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                item.SetInt("_ZWrite", 0);

                item.DisableKeyword("_ALPHATEST_ON");
                item.EnableKeyword("_ALPHABLEND_ON");
                item.renderQueue = 3000;
            }
            // Room1 Transparent Materials
            foreach (Material item in RoomTransMats_1)
            {
                Debug.Log("Testing ---------->>>");

                item.SetFloat("_Mode", 2);
                item.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                item.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                item.SetInt("_ZWrite", 0);

                item.DisableKeyword("_ALPHATEST_ON");
                item.EnableKeyword("_ALPHABLEND_ON");
                item.renderQueue = 3000;
            }
        }


        // Fading Room1 when the trigger button is pressed
        if (RoomCounter == 2)
        {
            foreach (Material item in RoomMats_2)
            {
                Debug.Log("Testing ---------->>>");

                item.SetFloat("_Mode", 2);
                item.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                item.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                item.SetInt("_ZWrite", 0);

                item.DisableKeyword("_ALPHATEST_ON");
                item.EnableKeyword("_ALPHABLEND_ON");
                item.renderQueue = 3000;
            }
        }
    }

    private void ReturnToNormal()
    {
        // Changing Room 1 back to visible
        if (RoomCounter == 1)
        {

            foreach (Material item in RoomMats_1)
            {
                item.SetFloat("_Mode", 0);
                item.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                item.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                item.SetInt("_ZWrite", 1);

                item.DisableKeyword("_ALPHATEST_ON");
                item.DisableKeyword("_ALPHABLEND_ON");
                item.DisableKeyword("_ALPHAPREMULTIPLY_ON");

                item.renderQueue = -1;
            }
        }
        // Change to Room1 Materials back to Transparent
        if (RoomCounter == 1)
        {

            foreach (Material item in RoomTransMats_1)
            {
                item.SetFloat("_Mode", 3);
                item.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                item.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                item.SetInt("_ZWrite", 0);

                item.DisableKeyword("_ALPHATEST_ON");
                item.DisableKeyword("_ALPHABLEND_ON");
                item.EnableKeyword("_ALPHAPREMULTIPLY_ON");

                item.renderQueue = 3000;
            }
        }


        // Changing Room 2 back to visible
        if (RoomCounter == 2)
        {
            foreach (Material item in RoomMats_2)
            {
                item.SetFloat("_Mode", 0);
                item.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                item.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                item.SetInt("_ZWrite", 1);

                item.DisableKeyword("_ALPHATEST_ON");
                item.DisableKeyword("_ALPHABLEND_ON");
                item.DisableKeyword("_ALPHAPREMULTIPLY_ON");

                item.renderQueue = -1;
            }
        }
        /*        
            m.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);

            m.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.…);

            m.SetInt("_ZWrite", 1);

            m.DisableKeyword("_ALPHATEST_ON");

            m.DisableKeyword("_ALPHABLEND_ON");

            m.DisableKeyword("_ALPHAPREMULTIPLY_ON");

            m.renderQueue = -1;
         */
    }
}
