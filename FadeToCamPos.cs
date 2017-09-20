using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToCamPos : MonoBehaviour
{
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

    public void Fade (bool showing, float duration)
    {
        isShowing = showing;
        isInTransition = true;
        this.duration = duration;
        transition = (isShowing) ? 0 : 1;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Fade(true, 1.25f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Fade(false, 1.25f);
        }

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
