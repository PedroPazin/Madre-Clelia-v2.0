using UnityEngine;

public enum STATE 
{
    DISABLED,
    WAITING,
    TYPING
}

public static class PlayerData
{
    public static string playerName;
}

public class DialogueSystem : MonoBehaviour
{
    public DialogueData dialogueData;

    int currentText = 0;
    bool finished = false;

    TypeTextAnimation typeText;
    DialogueUI dialogueUI;

    public STATE state;

    void Awake()
    {
        typeText = FindFirstObjectByType<TypeTextAnimation>();
        dialogueUI = FindFirstObjectByType<DialogueUI>();

        typeText.TypeFinished = OnTypeFinished;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = STATE.DISABLED;

    }

    // Update is called once per frame
    void Update()
    {
        // Spawn de objects
        if (ObjectManager.instance.objects.Length != 0)
        {
            if (finished)
            {
                foreach (GameObject obj in ObjectManager.instance.objects)
                {
                    obj.SetActive(true);
                }

            }
        }

        if (state == STATE.DISABLED) return;

        switch(state) 
        {
            case STATE.WAITING:
                Waiting();
                break;
            case STATE.TYPING:
                Typing();
                break;
                
        }

    }

    public void Next()
    {
        if (currentText == 0)
        {
            dialogueUI.Enable();
        }

        dialogueUI.SetName(dialogueData.talkScript[currentText].name == "PLAYER" ? PlayerData.playerName :dialogueData.talkScript[currentText].name);

        typeText.fullText = dialogueData.talkScript[currentText++].text;

        if (currentText == dialogueData.talkScript.Count) finished = true;

        typeText.StartTyping();
        state = STATE.TYPING;
    }

    

    private void OnTypeFinished()
    {
       state = STATE.WAITING; 
    }

    private void Waiting()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!finished)
            {
                Next();
            }
            else
            {
                dialogueUI.Disable();
                state = STATE.DISABLED;
                currentText = 0;
                finished = false;
            }
        }

    }

    private void Typing()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            typeText.Skip();
            state = STATE.WAITING;
        }
    }
}
