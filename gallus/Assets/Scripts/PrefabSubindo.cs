using UnityEngine;
using TMPro;

public class  PrefabSubindo : MonoBehaviour
{
    public float velocidadeSubida = 1.5f;
    public float duracao = 1f;

    private TextMeshPro texto;
    private float tempo;
    

    void Start()
    {
        texto = GetComponent<TextMeshPro>();
        Destroy(gameObject, duracao);
    }

    void Update()
    {
        transform.Translate(Vector3.up * velocidadeSubida * Time.deltaTime, Space.World);

        tempo += Time.deltaTime;
        Color cor = texto.color;
        cor.a = 1f - (tempo / duracao);
        texto.color = cor;
    }
}