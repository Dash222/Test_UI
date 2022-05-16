using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public static VideoPlayerManager instance = null;

    private VideoPlayer player = null;
    
    private bool isFullscreen = false;
    public bool IsFullscreen { get => isFullscreen; }

    void Awake()
    {
        if (!instance)
            instance = this;
    }
    void Start()
    {
        if(isFullscreen)
            Screen.orientation = ScreenOrientation.Landscape;

        if (!player)
            player = GetComponent<VideoPlayer>();
    }

    #region Play/Pause/Fullscreen Methods
    public void Play()
    {
        player?.Play();
    }
    public void Pause()
    {
        player?.Pause();
    }
    public void Fullscreen()// change the orientation of the screen for the fullscreen player
    {
        if (isFullscreen)
            Screen.orientation = ScreenOrientation.Portrait;
        
        else 
            Screen.orientation = ScreenOrientation.Landscape;

        isFullscreen = !isFullscreen;
    }
    #endregion

    #region utility Methods
    public float GetCurrentTime()
    {
        if (player)
            return (float)player.time;

        return 0.0f;
    }
    public float GetVideoLength()
    {
        if (player)
            return (float)player.length;

        return 0.0f;
    }

    public void SetCurrentTime(float newCurrentTime)// Set the current timecode of the video
    {
        if(player && !Mathf.Approximately((float)player.time, newCurrentTime))
            player.time = newCurrentTime;
    }
    #endregion
}
