using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    GameObject[] objects;
    int countObjets;
    public static ObjectManager instance;

    private void Awake()
    {
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objects = GameObject.FindGameObjectsWithTag("object");
        countObjets = objects.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountObjects()
    {
        countObjets--;
        if (countObjets <= 0)
        {
            SceneController.instance.NextLevel();
        }

    }
}
