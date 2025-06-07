using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject _player;
    public GameObject interactionText;
    private bool _canInteract;
    private bool _interacted;

    DialogueSystem dialogueSystem;

    private void Awake()
    {
        dialogueSystem = FindFirstObjectByType<DialogueSystem>();
    }
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
        if(_canInteract && dialogueSystem.state == STATE.DISABLED)
        {
            interactionText.SetActive(true);
            if(Input.GetKeyDown("e"))
            {
                dialogueSystem.Next();
            }
        }
        else
        {
            interactionText.SetActive(false);
        }
    }

}
