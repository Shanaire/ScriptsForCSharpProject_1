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
    public CameraManager CamManager;
    private List<Camera> RoomCams_ = new List<Camera>();

    //_________________________________________________________________________________________________________//

    // First we need to reference in instances of the different rooms and their renders.
    public List<GameObject> RoomsToFade = new List<GameObject>(); // Solid Objects
    public List<GameObject> RoomsTranspToFade = new List<GameObject>(); // Solid Objects

    // Room Counter
    public int RoomCounter = 0;

    // Accessing the material states of the materials
    //___________________________________ROOM 1____________________________________________//
    private List<Material> RoomTransMats_1 = new List<Material>(); // Transparent Materials of the Rooms 
    private List<Material> RoomMats_1 = new List<Material>(); // List of Room Mats
    private Renderer[] rend_1; // Renderer for Room solid objects
    //private Renderer[] rend_1_1; // Renderers for Room Trnasparent objects

    //___________________________________ROOM 2____________________________________________//
    private List<Material> RoomTransMats_2 = new List<Material>(); // Transparent Materials of the Rooms
    private List<Material> RoomMats_2 = new List<Material>(); // List of Room Mats 
    private Renderer[] rend_2; // Renderer for Room
    //private Renderer[] rend_2_1; // Renderers for Room Trnasparent objects

    //___________________________________ROOM 3____________________________________________//
    private List<Material> RoomTransMats_3 = new List<Material>(); // Transparent Materials of the Rooms
    private List<Material> RoomMats_3 = new List<Material>(); // List of Room Mats 
    private Renderer[] rend_3; // Renderer for Room
    //private Renderer[] rend_3_1; // Renderers for Room Trnasparent objects

    //___________________________________ROOM 4____________________________________________//
    private List<Material> RoomTransMats_4 = new List<Material>(); // Transparent Materials of the Rooms
    private List<Material> RoomMats_4 = new List<Material>(); // List of Room Mats 
    private Renderer[] rend_4; // Renderer for Room
    //private Renderer[] rend_4_1; // Renderers for Room Trnasparent objects

    //___________________________________ROOM 5____________________________________________//
    private List<Material> RoomTransMats_5 = new List<Material>(); // Transparent Materials of the Rooms
    private List<Material> RoomMats_5 = new List<Material>(); // List of Room Mats 
    private Renderer[] rend_5; // Renderer for Room
    //private Renderer[] rend_5_1; // Renderers for Room Trnasparent objects

    //___________________________________ROOM 6____________________________________________//
    private List<Material> RoomTransMats_6 = new List<Material>(); // Transparent Materials of the Rooms
    private List<Material> RoomMats_6 = new List<Material>(); // List of Room Mats 
    private Renderer[] rend_6; // Renderer for Room 
    //private Renderer[] rend_6_1; // Renderers for Room Trnasparent objects

    //___________________________________ROOM 7____________________________________________//
    private List<Material> RoomTransMats_7 = new List<Material>(); // Transparent Materials of Room
    private List<Material> RoomMats_7 = new List<Material>(); // List of Room Mats 
    private Renderer[] rend_7; // Renderer for Room 
    //private Renderer[] rend_7_1; // Renderers for Room  Trnasparent objects

    private void Awake()
    {
        //______________REFERENCE_________//
        // This is about making a reference to the different Room cameras that the Camera Manager is using for the Rooms so that I can acess them in this script
        RoomCams_.Add(CamManager.RoomCams[0].GetComponent<Camera>());
        RoomCams_.Add(CamManager.RoomCams[1].GetComponent<Camera>());
        RoomCams_.Add(CamManager.RoomCams[2].GetComponent<Camera>());
        RoomCams_.Add(CamManager.RoomCams[3].GetComponent<Camera>());
        RoomCams_.Add(CamManager.RoomCams[4].GetComponent<Camera>());
        RoomCams_.Add(CamManager.RoomCams[5].GetComponent<Camera>());
        RoomCams_.Add(CamManager.RoomCams[6].GetComponent<Camera>());
        //______________________________________________//
    }

    private void Start()
    {

        //_________________ROOM 1____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_1 = RoomsToFade[0].GetComponentsInChildren<Renderer>();
        //rend_1_1 = RoomsTranspToFade[0].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_1.Add(item_2);
            }
        }
        /*foreach (Renderer item in rend_1_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_1.Add(item_2);
            }
        }
        */
        //_________________ROOM 2____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_2 = RoomsToFade[1].GetComponentsInChildren<Renderer>();
        //rend_2_1 = RoomsTranspToFade[1].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_2)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_2.Add(item_2);
            }
        }
        /*foreach (Renderer item in rend_2_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_2.Add(item_2);
            }
        }
        */
        //_________________ROOM 3____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_3 = RoomsToFade[2].GetComponentsInChildren<Renderer>();
        //rend_3_1 = RoomsTranspToFade[2].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_3)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_3.Add(item_2);
            }
        }
        /*foreach (Renderer item in rend_3_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_3.Add(item_2);
            }
        }
        */
        //_________________ROOM 4____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_4 = RoomsToFade[3].GetComponentsInChildren<Renderer>();
        //rend_4_1 = RoomsTranspToFade[3].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_4)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_4.Add(item_2);
            }
        }
        /*foreach (Renderer item in rend_4_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_4.Add(item_2);
            }
        }
        */
        //_________________ROOM 5____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_5 = RoomsToFade[4].GetComponentsInChildren<Renderer>();
        //rend_5_1 = RoomsTranspToFade[4].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_5)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_5.Add(item_2);
            }
        }
        /*foreach (Renderer item in rend_5_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_5.Add(item_2);
            }
        }
        */
        //_________________ROOM 6____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_6 = RoomsToFade[5].GetComponentsInChildren<Renderer>();
        //rend_6_1 = RoomsTranspToFade[5].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_6)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_6.Add(item_2);
            }
        }
        /*foreach (Renderer item in rend_6_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_6.Add(item_2);
            }
        }
        */
        //_________________ROOM 7____________________//

        // This function adds all the renders of the object in the selected game object to the array of renderers
        rend_7 = RoomsToFade[6].GetComponentsInChildren<Renderer>();
        //rend_7_1 = RoomsTranspToFade[6].GetComponentsInChildren<Renderer>();

        // This then loops through the array and add each of the materials to the list of materials.
        foreach (Renderer item in rend_7)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomMats_7.Add(item_2);
            }
        }
        /*foreach (Renderer item in rend_7_1)
        {
            foreach (Material item_2 in item.materials)
            {
                RoomTransMats_7.Add(item_2);
            }
        }
        */
    }

    private void Update()
    {
        Initiating();
    }

    void Initiating()
    {
        // Making Room 1 Visible all all other Rooms Transparent
        if (RoomCams_[0].enabled == true) // Room Cam 1 Active
        {
            RoomCounter = 2;
            Debug.Log("TOFADING");
            CamManager.CameraTransition();
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[1], 0, 1);
            iTween.FadeTo(RoomsToFade[2], 0, 1);
            iTween.FadeTo(RoomsToFade[3], 0, 1);
            iTween.FadeTo(RoomsToFade[4], 0, 1);
            iTween.FadeTo(RoomsToFade[5], 0, 1);
            iTween.FadeTo(RoomsToFade[6], 0, 1);
        }
    
        // Making Room 2 Visible and all other Rooms Transparent
        if (RoomCams_[1].enabled == true) // Room Cam 2 Active
        {
            Debug.Log("TOFADING");
            CamManager.CameraTransition();
            RoomCounter = 1;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[0], 0, 1);
            iTween.FadeTo(RoomsToFade[2], 0, 1);
            iTween.FadeTo(RoomsToFade[3], 0, 1);
            iTween.FadeTo(RoomsToFade[4], 0, 1);
            iTween.FadeTo(RoomsToFade[5], 0, 1);
            iTween.FadeTo(RoomsToFade[6], 0, 1);
        }

        // Making Room 3 Visible and all other Rooms Transparent
        if (RoomCams_[2].enabled == true) // Room Cam 3 Active
        {
            Debug.Log("TOFADING");
            CamManager.CameraTransition();
            RoomCounter = 1;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[0], 0, 1);
            iTween.FadeTo(RoomsToFade[1], 0, 1);
            iTween.FadeTo(RoomsToFade[3], 0, 1);
            iTween.FadeTo(RoomsToFade[4], 0, 1);
            iTween.FadeTo(RoomsToFade[5], 0, 1);
            iTween.FadeTo(RoomsToFade[6], 0, 1);
        }

        // Making Room 4 Visible and all other Rooms Transparent
        if (RoomCams_[3].enabled == true) // Room Cam 4 Active
        {
            Debug.Log("TOFADING");
            CamManager.CameraTransition();
            RoomCounter = 1;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[0], 0, 1);
            iTween.FadeTo(RoomsToFade[1], 0, 1);
            iTween.FadeTo(RoomsToFade[2], 0, 1);
            iTween.FadeTo(RoomsToFade[4], 0, 1);
            iTween.FadeTo(RoomsToFade[5], 0, 1);
            iTween.FadeTo(RoomsToFade[6], 0, 1);
        }

        // Making Room 5 Visible and all other Rooms Transparent
        if (RoomCams_[4].enabled == true) // Room Cam 5 Active
        {
            Debug.Log("TOFADING");
            CamManager.CameraTransition();
            RoomCounter = 1;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[0], 0, 1);
            iTween.FadeTo(RoomsToFade[1], 0, 1);
            iTween.FadeTo(RoomsToFade[2], 0, 1);
            iTween.FadeTo(RoomsToFade[3], 0, 1);
            iTween.FadeTo(RoomsToFade[5], 0, 1);
            iTween.FadeTo(RoomsToFade[6], 0, 1);
        }

        // Making Room 6 Visible and all other Rooms Transparent
        if (RoomCams_[5].enabled == true) // Room Cam 6 Active
        {
            Debug.Log("TOFADING");
            CamManager.CameraTransition();
            RoomCounter = 1;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[0], 0, 1);
            iTween.FadeTo(RoomsToFade[1], 0, 1);
            iTween.FadeTo(RoomsToFade[2], 0, 1);
            iTween.FadeTo(RoomsToFade[3], 0, 1);
            iTween.FadeTo(RoomsToFade[4], 0, 1);
            iTween.FadeTo(RoomsToFade[6], 0, 1);
        }

        // Making Room 7 Visible and all other Rooms Transparent
        if (RoomCams_[6].enabled == true) // Room Cam 7 Active
        {
            Debug.Log("TOFADING");
            CamManager.CameraTransition();
            RoomCounter = 1;
            ChangeToTransparent();
            iTween.FadeTo(RoomsToFade[0], 0, 1);
            iTween.FadeTo(RoomsToFade[1], 0, 1);
            iTween.FadeTo(RoomsToFade[2], 0, 1);
            iTween.FadeTo(RoomsToFade[3], 0, 1);
            iTween.FadeTo(RoomsToFade[4], 0, 1);
            iTween.FadeTo(RoomsToFade[5], 0, 1);
        }

        // Returning Room 1 to its normal state
        if (Input.GetKeyDown(KeyCode.X))
        {
            RoomCounter = 1;
            iTween.FadeTo(RoomsToFade[0], 1, 2);
            Invoke("ReturnToNormal", 2f);
        }


    }

    // Function to change the objects initial material to transparent
    private void ChangeToTransparent()
    {
        // Fading Room 1 when the trigger button is pressed
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
            // Room 1 Transparent Materials
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

        // Fading Room 2 when the trigger button is pressed
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

        // Fading Room 3 when the trigger button is pressed
        if (RoomCounter == 3)
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

        // Fading Room 4 when the trigger button is pressed
        if (RoomCounter == 4)
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

        // Fading Room 5 when the trigger button is pressed
        if (RoomCounter == 5)
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

        // Fading Room 5 when the trigger button is pressed
        if (RoomCounter == 5)
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

        // Fading Room 6 when the trigger button is pressed
        if (RoomCounter == 6)
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

        // Fading Room 7 when the trigger button is pressed
        if (RoomCounter == 7)
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
