using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Object : MonoBehaviour
{
    private GameObject _player;
    public GameObject interactionText;
    private bool _canInteract;
    private bool _interacted;
    public GameObject info;


    public int health;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("player");        
        interactionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {
            if (PauseMenu.instance.isPaused)
            {
                return;
            }

            GetDistance();
        }  

        if(_interacted)
        {
            interactionText.SetActive(false);
            Destroy(gameObject);
            ObjectManager.instance.CountObjects();
        }      
    }

    private void GetDistance()
    {
        float dist = Vector2.Distance(transform.position, _player.transform.position);
        _canInteract = dist <= 1.75f;
        if(_canInteract)
        {
            interactionText.SetActive(true);
            if(Input.GetKeyDown("e"))
            {
                StartCoroutine(Interact());
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

    public IEnumerator Interact()
    {
        info.SetActive(true);
        PauseMenu.instance.canPause = false;
        yield return new WaitUntil(() => Input.GetKeyDown("escape"));
        PauseMenu.instance.canPause = true;
        info.SetActive(false);
        _interacted = true;
    }
}
