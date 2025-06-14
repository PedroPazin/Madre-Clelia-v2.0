using System;
using Unity.VisualScripting;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public FunctionType function;

    [SerializeField] private GameObject flagFadeIn;
    [SerializeField] private GameObject flagFadeOut;
    [SerializeField] private float duration;
    [SerializeField] private float delay;
    [SerializeField] private LeanTweenType easeType;
    public float dif;

    public enum FunctionType
    {
        FadeInX,
        FadeInY,
        FadeOutX,
        FadeOutY,
    }

    private void OnEnable()
    {
        switch (function)
        {
            case FunctionType.FadeInX:
                FadeInX();
                break;
            case FunctionType.FadeInY:
                FadeInY();
                break;
            case FunctionType.FadeOutX:
                FadeOutX();
                break;
            case FunctionType.FadeOutY:
                FadeOutY();
                break;
        }
    }

    public void FadeInY()
    {
        LeanTween.moveY(gameObject, flagFadeIn.transform.position.y + dif, duration).setEase(easeType).setDelay(delay);
    }

    public void FadeInX()
    {
        LeanTween.moveX(gameObject, flagFadeIn.transform.position.x + dif, duration).setEase(easeType).setDelay(delay);
    }

    public void FadeOutX()
    {
        LeanTween.moveX(gameObject, flagFadeOut.transform.position.x + dif, duration).setEaseInBack().setDelay(delay);
    }

    public void FadeOutY()
    {
        LeanTween.moveY(gameObject, flagFadeOut.transform.position.y + dif, duration).setEaseInBack().setDelay(delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
