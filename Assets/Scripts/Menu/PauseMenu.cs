using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject[] buttons;

    public bool isPaused;
    public bool canPause;

    public static PauseMenu instance;

    private void Awake()
    {

        pauseMenu.SetActive(false);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-1552f, -100 + (-130 * i));
        }

        isPaused = false;
        canPause = true;
    }

    void Update()
    {
        if (!canPause)
        {
            return;
        }

        if (Input.GetKeyDown("escape") && isPaused)
        {
            Resume();
        }
        else if (Input.GetKeyDown("escape") && !isPaused)
        {
            Pause();
        }
    }

    private IEnumerator FadeOutButtons()
    {
        foreach (GameObject btn in buttons)
        {
            btn.GetComponent<FadeIn>().FadeOutX();
        }
        yield return new WaitForSeconds(1f);
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        StartCoroutine(FadeOutButtons());
    }

    public void Quit()
    {
        Application.Quit();
    }

}
