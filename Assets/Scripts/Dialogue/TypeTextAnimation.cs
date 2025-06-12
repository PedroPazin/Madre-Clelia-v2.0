using System.Collections;
using TMPro;
using UnityEngine;
using System;

public class TypeTextAnimation : MonoBehaviour
{
    public Action TypeFinished;

    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;

    public string fullText;

    private bool _isDone;

    Coroutine coroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTyping()
    {
        coroutine = StartCoroutine(TypeText());
        StartCoroutine(TypeTextSound());
    }

    IEnumerator TypeText()
    {
        _isDone = false;
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for (int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
        _isDone = true;
        TypeFinished?.Invoke();
    }

    private IEnumerator TypeTextSound()
    {
        while (!_isDone)
        {
            AudioManager.instance.PlaySFXOneTime(AudioManager.instance.dialogue, AudioManager.instance.dialogueSfx);
            yield return new WaitForSeconds(typeDelay + 0.05f);
        }
    }

    public void Skip()
    {
        StopCoroutine(coroutine);
        _isDone = true;
        textObject.maxVisibleCharacters = textObject.text.Length;
    }
}
