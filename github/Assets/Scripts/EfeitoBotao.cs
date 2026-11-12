using UnityEngine;
using UnityEngine.EventSystems;

public class EfeitoBotao : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Configurações de Escala")]
    [Tooltip("Tamanho que o botão vai ficar ao passar o mouse (ex: 1.1 = 10% maior)")]
    public float escalaHover = 1.1f;

    [Tooltip("Velocidade da transição suave")]
    public float velocidade = 10f;

    private Vector3 escalaOriginal;
    private Vector3 escalaAlvo;

    void Start()
    {
        // Guarda o tamanho inicial do botão
        escalaOriginal = transform.localScale;
        escalaAlvo = escalaOriginal;
    }

    void Update()
    {
        // Faz a transição suave entre a escala atual e a escala desejada
        // Usa unscaledDeltaTime para funcionar mesmo se o jogo estiver pausado (Time.timeScale = 0)
        transform.localScale = Vector3.Lerp(transform.localScale, escalaAlvo, Time.unscaledDeltaTime * velocidade);
    }

    // Disparado quando o mouse entra na área do botão
    public void OnPointerEnter(PointerEventData eventData)
    {
        escalaAlvo = escalaOriginal * escalaHover;
    }

    // Disparado quando o mouse sai da área do botão
    public void OnPointerExit(PointerEventData eventData)
    {
        escalaAlvo = escalaOriginal;
    }

    // Garante que o botão volte ao tamanho normal se for desativado no meio da animação
    void OnDisable()
    {
        if (escalaOriginal != Vector3.zero)
        {
            transform.localScale = escalaOriginal;
            escalaAlvo = escalaOriginal;
        }
    }
}
