using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject configMenu;
    public GameObject[] buttons;
    public GameObject[] otherScreenButtons;

    public bool canPause;

    public static PauseMenu instance;

    public enum ACTIVE_OPTION
    {
        CONFIG,
        MAIN,
        NONE,
        INTERACTING,
    }

    public ACTIVE_OPTION activeOption;

    private void Awake()
    {

        pauseMenu.SetActive(false);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        canPause = true;
        activeOption = ACTIVE_OPTION.NONE;
    }

    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            switch (activeOption)
            {
                case ACTIVE_OPTION.NONE:
                    Pause();
                    break;
                case ACTIVE_OPTION.MAIN:
                    Resume();
                    break;
                case ACTIVE_OPTION.CONFIG:
                    Return();
                    break;
                case ACTIVE_OPTION.INTERACTING:
                    break;
            }
        }
    }

    private IEnumerator FadeOutButtons(GameObject offOption, GameObject onOption, ACTIVE_OPTION option)
    {
        foreach (GameObject btn in buttons)
        {
            btn.GetComponent<FadeIn>().FadeOutX();
        }
        yield return new WaitForSeconds(1f);
        if (onOption != null) onOption.SetActive(true);
        offOption.SetActive(false);
        activeOption = option;
    }

    private IEnumerator FadeOutButtonsY(GameObject offOption, GameObject onOption, ACTIVE_OPTION option)
    {
        foreach (GameObject btn in otherScreenButtons)
        {
            btn.GetComponent<FadeIn>().FadeOutY();
        }
        yield return new WaitForSeconds(1f);
        if (onOption != null) onOption.SetActive(true);
        offOption.SetActive(false);
        activeOption = option;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        activeOption = ACTIVE_OPTION.MAIN;
    }

    public void Return()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        StartCoroutine(FadeOutButtonsY(configMenu, pauseMenu, ACTIVE_OPTION.MAIN));
    }

    public void ReturnMainMenu()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        SceneController.instance.LoadSceneByIndex(0);
    }

    public void Config()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        StartCoroutine(FadeOutButtons(pauseMenu, configMenu, ACTIVE_OPTION.CONFIG));
    }

    public void Resume()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        StartCoroutine(FadeOutButtons(pauseMenu, null, ACTIVE_OPTION.NONE));
    }

    public void Quit()
    {
        AudioManager.instance.PlaySFXOneTime(AudioManager.instance.click, AudioManager.instance.sfxSource);
        Application.Quit();
    }

}
