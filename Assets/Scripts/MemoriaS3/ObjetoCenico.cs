using UnityEngine;

public class ObjetoCenico : MonoBehaviour
{
    public Sprite spriteIncompleto;
    public Sprite spriteCompleto;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = spriteIncompleto;
    }

    public void Ativar()
    {
        sr.sprite = spriteCompleto;
        // Aqui você pode adicionar efeitos visuais ou sons
    }
}