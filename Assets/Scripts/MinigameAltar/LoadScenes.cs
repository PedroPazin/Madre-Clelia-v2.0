using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    public void loadScene()
    {
        NextLevel();
    }

    private void NextLevel()
    {
        SceneController.instance.NextLevel();
    }

}
