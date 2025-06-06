using UnityEngine;
using UnityEngine.UI;

public class CartaMemoria : MonoBehaviour
{
    public Image imagemFrente;
    public GameObject verso;

    [HideInInspector]
    public string idObjeto;
    private MemoriaManager manager;

    private bool revelada = false;

    public void Configurar(MemoriaManager.ParMemoria par, MemoriaManager mgr)
    {
        idObjeto = par.idObjeto;
        imagemFrente.sprite = par.imagem;
        manager = mgr;
        verso.SetActive(true);
        revelada = false;
    }

    public void VirarCarta()
    {
        if (revelada) return;

        revelada = true;
        verso.SetActive(false);
        manager.CartaVirada(this);
    }

    public void Resetar()
    {
        revelada = false;
        verso.SetActive(true);
    }
}
