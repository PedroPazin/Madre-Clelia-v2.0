using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField]
    private Animator _transitionAnim;

    public GameObject transitionCanvas;

    private void Awake()
    {
        transitionCanvas.SetActive(false);
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

    public void NextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    public void LoadSceneByIndex(int index)
    {
        StartCoroutine(LoadSpecificScene(index));
    }

    public void LoadCredits()
    {
        StartCoroutine(LoadCreditsScene());
    }

    IEnumerator LoadLevel()
    {
        transitionCanvas.SetActive(true);
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        yield return SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        _transitionAnim.SetTrigger("Start");
        transitionCanvas.SetActive(false);
    }

    private IEnumerator LoadSpecificScene(int sceneIndex)
    {
        transitionCanvas.SetActive(true);
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        yield return SceneManager.LoadSceneAsync(sceneIndex);
        _transitionAnim.SetTrigger("Start");
        transitionCanvas.SetActive(false);
    }

    private IEnumerator LoadCreditsScene()
    {
        transitionCanvas.SetActive(true);
        _transitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        yield return SceneManager.LoadSceneAsync(5);
        _transitionAnim.SetTrigger("Start");
        transitionCanvas.SetActive(false);
    }
}
