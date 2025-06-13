using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject chooseNameOption;
    public GameObject menuOptions;
    public GameObject configOptions;
    public TMP_InputField inputField;

    public GameObject[] buttons;
    public GameObject[] buttonsName;

    private enum ACTIVE_OPTION
    {
        CONFIG,
        MAIN,
        CHOOSE,
    }

    private ACTIVE_OPTION activeOption;


    private void Awake()
    {
    }

    public void Start()
    {
        chooseNameOption.SetActive(false);
        menuOptions.SetActive(true);
        configOptions.SetActive(false);
        activeOption = ACTIVE_OPTION.MAIN;

    }

    public void Update()
    {
        if (activeOption != ACTIVE_OPTION.MAIN)
        {
            if (Input.GetKeyDown("escape"))
            {
                switch (activeOption)
                {
                    case ACTIVE_OPTION.CHOOSE:
                        Return(chooseNameOption);
                        break;
                    case ACTIVE_OPTION.CONFIG:
                        Return(configOptions);
                        break;

                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayGame();
            }
        }
    }
    public IEnumerator FadeInButtons(GameObject offOption)
    {
        foreach (GameObject btn in buttonsName)
        {
            btn.GetComponent<FadeIn>().FadeOutY();
        }
        yield return new WaitForSeconds(1f);
        offOption.SetActive(false);
        menuOptions.SetActive(true);
        activeOption = ACTIVE_OPTION.MAIN;
    }

    public void Config()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        activeOption = ACTIVE_OPTION.CONFIG;
        StartCoroutine(FadeOutButtons(configOptions));
    }

    public void Credits()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        SceneController.instance.LoadCredits();
    }

    public void PlayGame()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        if (inputField.text == "") return;
        PlayerData.playerName = inputField.text;
        SceneController.instance.NextLevel();
    }

    public void ChooseName()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        StartCoroutine(FadeOutButtons(chooseNameOption));
        activeOption = ACTIVE_OPTION.CHOOSE;
    }

    public void Return(GameObject offOption)
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        StartCoroutine(FadeInButtons(offOption));
    }

    public IEnumerator FadeOutButtons(GameObject OnOption)
    {
        foreach (GameObject btn in buttons)
        {
            btn.GetComponent<FadeIn>().FadeOutX();
        }
        yield return new WaitForSeconds(1f);
        OnOption.SetActive(true);
        menuOptions.SetActive(false);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        Application.Quit();
    }
}
