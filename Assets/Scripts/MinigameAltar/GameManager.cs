using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int correctDrops = 0;
    public int totalCorrectDropsNeeded = 7;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void RegisterCorrectDrop()
    {
         correctDrops++;
        Debug.Log("Acertos: " + correctDrops + "/" + totalCorrectDropsNeeded);

        if (correctDrops >= totalCorrectDropsNeeded)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }
}