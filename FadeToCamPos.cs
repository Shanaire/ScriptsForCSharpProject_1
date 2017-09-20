using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToCamPos : MonoBehaviour
{
    /* 
     * This script is to be used to fade the camera when the camera switch is about to happen
     * 
     * 
     */


    //_________________________________REFERENCED FILES______________________________//

    public CameraManager CamManager;
    private List<Camera> RoomCams_ = new List<Camera>();

    //_______________________________________________________________________________//

    public static FadeToCamPos Instance { set; get; }

    public Image FadeImage;
    private bool isInTransition;
    private float transition;
    private bool isShowing;
    public float duration;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
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


    public void Fade(bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;

    }
    private void Update()
    {
        FadeTransition();
    }

    public void RoomFadeOUT()
    {
        Debug.Log("Fading Transition");
        Fade(true, .5f);
    }

    public void RoomFadeIN()
    {
        Debug.Log("Fading Transition");
        Fade(false, .5f);
    }


    void FadeTransition()
    {
        // Controls the Transition from Alpha 0 to Alpha 1
        if (!isInTransition)
            return;
        transition += (isShowing) ? Time.deltaTime * (1 / duration) : -Time.deltaTime * (1 / duration);
        FadeImage.color = Color.Lerp(new Color(1, 1, 1, 0), Color.white, transition);

        if (transition > 1 || transition < 0)
        {
            isInTransition = false;
        }
    }
}
