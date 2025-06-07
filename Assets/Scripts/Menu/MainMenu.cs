using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject chooseNameOption;
    public GameObject menuOptions;
    public TMP_InputField inputField;

    public GameObject[] buttons;
    public GameObject[] buttonsName;

    public void Start()
    {
        chooseNameOption.SetActive(false);
        menuOptions.SetActive(true);

    }

    public void Update()
    {
        if (chooseNameOption.activeSelf)
        {
            if (Input.GetKeyDown("escape"))
            {
                StartCoroutine(FadeInButtons());
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayGame();
            }
        }
    }
    public IEnumerator FadeInButtons()
    {
        foreach (GameObject btn in buttonsName)
        {
            btn.GetComponent<FadeIn>().FadeOutY();
        }
        yield return new WaitForSeconds(1f);
        chooseNameOption.SetActive(false);
        menuOptions.SetActive(true);
    }

    public void PlayGame()
    {
        PlayerData.playerName = inputField.text;
        SceneManager.LoadSceneAsync(1);
    }

    public void ChooseName()
    {
        StartCoroutine(FadeOutButtons());
    }

    public IEnumerator FadeOutButtons()
    {
        foreach (GameObject btn in buttons)
        {
            btn.GetComponent<FadeIn>().FadeOutX();
        }
        yield return new WaitForSeconds(1f);
        chooseNameOption.SetActive(true);
        menuOptions.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
