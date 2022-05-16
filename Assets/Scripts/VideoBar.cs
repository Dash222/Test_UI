using UnityEngine;
using UnityEngine.UI;

public class VideoBar : MonoBehaviour
{
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button pauseButton = null;
    [SerializeField] private Button fullscreenButton = null;
    [SerializeField] private TMPro.TMP_Text timeText = null;
    [SerializeField] private Slider timeSlider = null;

    void Start()
    {
        VideoPlayerManager playerManager = VideoPlayerManager.instance;

        if (playerManager)
        {
            if (playButton)
                playButton.onClick.AddListener(playerManager.Play);

            if (pauseButton)
                pauseButton.onClick.AddListener(playerManager.Pause);

            if (fullscreenButton)
                fullscreenButton.onClick.AddListener(playerManager.Fullscreen);

            if (timeSlider)
            {
                timeSlider.onValueChanged.AddListener(playerManager.SetCurrentTime);
                timeSlider.minValue = 0.0f;
                timeSlider.maxValue = playerManager.GetVideoLength();
            }
        }
    }

    private void Update()
    {
        VideoPlayerManager playerManager = VideoPlayerManager.instance;

        float time = playerManager.GetCurrentTime();

        if (timeText)// Convert seconds into HH:MM::SS
        {
            float hours = time / 3600f;
            int troncateHours = (int)hours;
            float minutes = (hours - (float)troncateHours) * 60f;
            int troncateMinutes = (int)minutes;
            float seconds = (minutes - (float)troncateMinutes) * 60f;

            string minutesText = "";
            if (minutes < 10)
                minutesText = "0" + troncateMinutes.ToString();
            else
                minutesText = troncateMinutes.ToString();

            string secondText = "";
            if (seconds < 10)
                secondText = "0" + ((int)seconds).ToString();
            else
                secondText = ((int)seconds).ToString();

            timeText.text = troncateHours.ToString() + ":" + minutesText.ToString() + ":" + secondText;
        }

        if (timeSlider)
        {
            if (!Mathf.Approximately(timeSlider.maxValue, playerManager.GetVideoLength()))
                timeSlider.maxValue = playerManager.GetVideoLength();

            timeSlider.value = time;
        }
    }
}
