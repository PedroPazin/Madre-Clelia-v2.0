using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Object : MonoBehaviour
{
    private GameObject _player;
    private RectTransform _rt;
    public GameObject interactionText;
    private bool _canInteract;
    private bool _interacted;
    public GameObject info;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("player");        
        _rt = interactionText.GetComponent<RectTransform>();
        interactionText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_player != null)
        {
            GetDistance();
        }  

        if(_canInteract && _interacted)
        {
            interactionText.SetActive(false);
            Destroy(gameObject);
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
        yield return new WaitUntil(() => Input.GetKeyDown("escape"));
        info.SetActive(false);
        _interacted = true;
    }
}
