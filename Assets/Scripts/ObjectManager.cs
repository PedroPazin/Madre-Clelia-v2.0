using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance { get; private set; }

    // Variables

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else 
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
