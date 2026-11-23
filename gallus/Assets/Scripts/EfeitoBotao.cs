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
       
        escalaOriginal = transform.localScale;
        escalaAlvo = escalaOriginal;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, escalaAlvo, Time.unscaledDeltaTime * velocidade);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        escalaAlvo = escalaOriginal * escalaHover;
    }

  
    public void OnPointerExit(PointerEventData eventData)
    {
        escalaAlvo = escalaOriginal;
    }

    
    void OnDisable()
    {
        if (escalaOriginal != Vector3.zero)
        {
            transform.localScale = escalaOriginal;
            escalaAlvo = escalaOriginal;
        }
    }
}
