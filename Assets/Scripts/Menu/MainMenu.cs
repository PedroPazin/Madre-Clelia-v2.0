using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject chooseNameOption;
    public GameObject menuOptions;
    public TMP_InputField inputField;

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
                chooseNameOption.SetActive(false);
                menuOptions.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                PlayGame();
            }
        }
    }

    public void PlayGame()
    {
        PlayerData.playerName = inputField.text;
        SceneManager.LoadSceneAsync(1);
    }

    public void ChooseName()
    {
        chooseNameOption.SetActive(true);
        menuOptions.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
