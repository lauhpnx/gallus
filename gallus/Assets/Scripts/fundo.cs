using UnityEngine;

public class fundo : MonoBehaviour
{
    public float velocidade = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime); // isso faz o funod " andar ".
    }
}
