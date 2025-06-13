using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source ------------")]
    [SerializeField] AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioSource dialogueSfx;
    public AudioSource walkingSfx;

    [Header("------------ Audio Clip ------------")]
    public AudioClip click;
    public AudioClip dialogue;
    public AudioClip music;
    public AudioClip grass;
    public AudioClip stone;
    public AudioClip wood;


    public static AudioManager instance;
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

    private void Start()
    {
        musicSource.clip = music;
        musicSource.Play();
    }

    public void PlaySFXOneTime(AudioClip clip, AudioSource source)
    {
        source.PlayOneShot(clip);
    }

    public void PlaySFXLoop(AudioClip clip, AudioSource source)
    {
        Debug.Log(source + " " + clip);
        source.clip = clip;
        source.Play();
    }

}
