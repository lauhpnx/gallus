using UnityEngine;

public class MovimentoMilho : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f; // Ajuste a velocidade como preferir

    void Update()
    {
        // Vector3.down faz o objeto mover-se para baixo no eixo Y a cada frame
        transform.Translate(Vector3.down * velocidade * Time.deltaTime, Space.World);

        // Se o milho passar da parte de baixo da tela, ele destrói-se para não pesar o jogo
        // Se a sua câmara for muito grande, altere o -10f para um número menor (ex: -15f)
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}