// === MemoriaManager.cs ===
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MemoriaManager : MonoBehaviour
{
    [System.Serializable]
    public class ParMemoria
    {
        public string idObjeto;
        public Sprite imagem;
        [TextArea]
        public string descricao;
    }

    [Header("Cartas e Layout")]
    public GameObject cartaPrefab;
    public Transform gridCartas;

    [Header("Popup de Descrição")]
    public GameObject painelPopup;

    public GameObject painelMemoria;
    public Image popupImagem;
    public TMP_Text popupTexto;

    [Header("Controle de Fluxo")]
    public IrmaDialogo irmaDialogo;

    public List<ParMemoria> pares;

    private List<GameObject> cartasInstanciadas = new List<GameObject>();
    private CartaMemoria primeiraCarta = null;
    private int paresEncontrados = 0;
    public bool bloqueandoClique = false;

    public void IniciarJogo()
    {

        LimparCartas();

        List<ParMemoria> todasCartas = new List<ParMemoria>(pares);
        todasCartas.AddRange(pares);
        Embaralhar(todasCartas);

        foreach (ParMemoria par in todasCartas)
        {
            GameObject novaCarta = Instantiate(cartaPrefab, gridCartas);
            CartaMemoria script = novaCarta.GetComponent<CartaMemoria>();
            script.Configurar(par, this);
            cartasInstanciadas.Add(novaCarta);
        }
    }

    public void CartaVirada(CartaMemoria carta)
{
    if (bloqueandoClique || carta == primeiraCarta) return;

    if (primeiraCarta == null)
    {
        primeiraCarta = carta;
    }
    else
    {
        bloqueandoClique = true;

        // Verifica se as cartas são iguais
        if (primeiraCarta.idObjeto == carta.idObjeto)
        {
            MostrarPopup(carta);
            AtivarObjetoNaCena(carta.idObjeto);

            // Garante que ambas fiquem reveladas
            carta.FixarComoRevelada();
            primeiraCarta.FixarComoRevelada();

            primeiraCarta = null;
            bloqueandoClique = false;
            paresEncontrados++;

            if (paresEncontrados == pares.Count)
            {
                StartCoroutine(EncerrarMinigame());
            }
        }
        else
        {
            StartCoroutine(ResetarCartasComDelay(carta, primeiraCarta));
        }
    }
}
    IEnumerator ResetarCartasComDelay(CartaMemoria cartaA, CartaMemoria cartaB)
    {
        yield return new WaitForSeconds(1f);

        cartaA.Resetar();
        cartaB.Resetar();

        primeiraCarta = null;
        bloqueandoClique = false;
    }

    IEnumerator EncerrarMinigame()
    {
        yield return new WaitUntil(() => painelPopup.activeSelf == false);
        yield return new WaitForSeconds(0.5f); // pequena pausa antes de fechar
        painelPopup.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        painelMemoria.SetActive(false);
        irmaDialogo.IniciarDialogoFinal();

    }


    void MostrarPopup(CartaMemoria carta)
    {
        ParMemoria par = pares.Find(p => p.idObjeto == carta.idObjeto);
        if (par != null)
        {
            popupImagem.sprite = par.imagem;
            popupTexto.text = par.descricao;
            painelPopup.SetActive(true);
        }
    }

    void AtivarObjetoNaCena(string idObjeto)
    {
        GameObject obj = GameObject.Find(idObjeto);
        if (obj != null)
        {
            ObjetoCenico cenico = obj.GetComponent<ObjetoCenico>();
            if (cenico != null)
                cenico.Ativar();
        }
    }

    void LimparCartas()
    {
        foreach (GameObject carta in cartasInstanciadas)
        {
            Destroy(carta);
        }
        cartasInstanciadas.Clear();
    }

    void Embaralhar(List<ParMemoria> lista)
    {
        for (int i = 0; i < lista.Count; i++)
        {
            ParMemoria temp = lista[i];
            int rand = Random.Range(i, lista.Count);
            lista[i] = lista[rand];
            lista[rand] = temp;
        }
    }

    void Start()
    {
        painelPopup.SetActive(false);
        IniciarJogo();
    }
}
