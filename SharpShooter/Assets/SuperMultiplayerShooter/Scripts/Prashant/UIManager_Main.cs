using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager_Main : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField characterName;


    [SerializeField]
    private GameObject characterScreenPanel;

    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private GameObject mainPanel;


    private void Start()
    {

        nextButton.onClick.AddListener(OnNextButtonClick);

        characterName.text = $"Player{UnityEngine.Random.Range(1000, 9999)}";


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

    private void OnNextButtonClick()
    {
        characterScreenPanel.SetActive(false);
        mainPanel.SetActive(true);

        PlayerPrefs.SetInt(StaticData.characterSelected, 1);

        StaticData.userId = $"ID_{UnityEngine.Random.Range(10000000 , 999999999)}";

        PlayerPrefs.SetString("UserID", StaticData.userId);
        PlayerPrefs.SetString(StaticData.player_Name, characterName.text);
    }
}
