using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Main : MonoBehaviour
{
    [SerializeField]
    private GameObject characterScreenPanel;
    [SerializeField]
    private InputField playerName;
    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private GameObject mainPanel;


    private void Start()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);

        if (PlayerPrefs.HasKey(StaticData.characterSelected))
        {
            if (PlayerPrefs.GetInt(StaticData.characterSelected) == 0)
            {
                Debug.Log("character Not Selected yet");
            }
            else
            {
                characterScreenPanel.SetActive(false);
                mainPanel.SetActive(true);
            }
        }
        

    }

    private void OnNextButtonClick()
    {
        characterScreenPanel.SetActive(false);
        mainPanel.SetActive(true);

        PlayerPrefs.SetInt(StaticData.characterSelected, 1);

    }
}
