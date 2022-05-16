using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance = null;

    [SerializeField] Canvas portraitCanvas = null;
    [SerializeField] Canvas playerCanvas = null;

    private ScreenOrientation previousOrientation = ScreenOrientation.Portrait;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        InitSceenState();
    }

    void Update()
    {
        UpdateScreenState();
    }

    #region Screen Methods
    private void InitSceenState()
    {
        bool isPlayerFullscreen = false;

        if (VideoPlayerManager.instance)
            isPlayerFullscreen = VideoPlayerManager.instance.IsFullscreen;

        if (!isPlayerFullscreen)
            SetScreen();

        PlayerFullscreen(isPlayerFullscreen);

        previousOrientation = Screen.orientation;
    }
    private void UpdateScreenState()
    {
        bool isPlayerFullscreen = false;

        if (VideoPlayerManager.instance)
            isPlayerFullscreen = VideoPlayerManager.instance.IsFullscreen;

        if (previousOrientation != Screen.orientation && !isPlayerFullscreen)
            SetScreen();
        
        PlayerFullscreen(isPlayerFullscreen);
    }

    private void SetScreen()// able/disable the portrait canvas
    {
        previousOrientation = Screen.orientation;

        if (Screen.orientation == ScreenOrientation.Portrait)
            portraitCanvas?.gameObject.SetActive(true);

        else
            portraitCanvas?.gameObject.SetActive(false);
    }
    private void PlayerFullscreen(bool isPlayerFullscreen)//Play fullscreen for the player
    {
        if (isPlayerFullscreen)
        {
            portraitCanvas?.gameObject.SetActive(false);
            playerCanvas?.gameObject.SetActive(true);
        }
        else
        {
            portraitCanvas?.gameObject.SetActive(true);
            playerCanvas?.gameObject.SetActive(false);
        }
    }
    #endregion
}
