using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpisodeName : MonoBehaviour
{
    [SerializeField] TMPro.TMP_InputField episodeInputField = null;
    TMPro.TMP_Text episodeNameText = null;

    void Start()
    {
        episodeNameText = GetComponent<TMPro.TMP_Text>();
        if (episodeInputField)
        {
            episodeInputField.onValueChanged.AddListener(UpdateEpisodeName);

            if (episodeNameText)
                episodeNameText.text = episodeInputField.text;
        }
    }

    void UpdateEpisodeName(string newName)
    {
        if(episodeNameText)
            episodeNameText.text = newName;
    }
}
