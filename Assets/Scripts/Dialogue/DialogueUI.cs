using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using System.Security.Cryptography.X509Certificates;

public class DialogueUI : MonoBehaviour
{
    Image background;
    TextMeshProUGUI nameText;
    TextMeshProUGUI talkText;

    public GameObject enterKeybind;

    public float speed = 10f;
    bool isOpen = false;

    void Awake()
    {
        background = transform.GetChild(0).GetComponent<Image>();
        nameText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        talkText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            background.fillAmount = Mathf.Lerp(background.fillAmount, 1, speed * Time.deltaTime);
        }
        else
        {
            background.fillAmount = Mathf.Lerp(background.fillAmount, 0, speed * Time.deltaTime);
        }
    }

    private IEnumerator ShowEnter()
    {
        yield return new WaitForSeconds(0.3f);
        enterKeybind.SetActive(true);
    }
    public void SetName(string name)
    {
        nameText.text = name;
    }

    public void Enable()
    {
        StartCoroutine(ShowEnter());
        background.fillAmount = 0;
        isOpen = true;
    }

    public void Disable()
    {
        enterKeybind.SetActive(false);
        isOpen = false;
        nameText.text = "";
        talkText.text = "";
    }
}
