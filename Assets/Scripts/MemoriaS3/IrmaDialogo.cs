using UnityEngine;

public class IrmaDialogo : MonoBehaviour
{
    public DialogueSystem dialogueSystem;
    public DialogueData intro3;
    public DialogueData final3;

    public GameObject painelMemoria;
    public MemoriaManager memoriaManager;

    private bool esperandoMinigame = false;


    public void IniciarDialogoInicial()
    {
        Debug.Log("Dialogo começou");
        esperandoMinigame = true;
        dialogueSystem.dialogueData = intro3;

        // Remover listeners duplicados por segurança
        dialogueSystem.OnDialogueEnd -= OnIntroTerminou;
        dialogueSystem.OnDialogueEnd += OnIntroTerminou;

        dialogueSystem.Next();
    }

    void OnIntroTerminou()
    {
        if (esperandoMinigame)
        {
            esperandoMinigame = false;
            Debug.Log("✅ Diálogo finalizado! Iniciando minigame.");

            painelMemoria.SetActive(true);
            memoriaManager.IniciarJogo();

            // Remove listener após uso
            dialogueSystem.OnDialogueEnd -= OnIntroTerminou;
        }
    }

    bool dialogueSystemFinalizou()
    {
        return !dialogueSystem.dialogueUI.gameObject.activeSelf;
    }

    public void IniciarDialogoFinal()
    {
        dialogueSystem.dialogueData = final3;
        dialogueSystem.OnDialogueEnd -= OnIntroTerminou;
        dialogueSystem.OnDialogueEnd += SceneController.instance.LoadCredits;
        dialogueSystem.Next();
    }

}
