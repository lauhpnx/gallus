using UnityEngine;

public class GalinhaController : MonoBehaviour
{
    public GameObject ovoPrefab; // Arraste o Prefab do ovo aqui no Inspetor
    public Transform pontoDeDisparo; // Um objeto vazio na ponta do bico
    public float intervaloTiro = 0.5f;
    private float cronometroTiro;

    void Update()
    {
        cronometroTiro += Time.deltaTime;

        // Verifica se apertou Espaço e se o tempo de espera acabou
        if (Input.GetKeyDown(KeyCode.Space) && cronometroTiro >= intervaloTiro)
        {
            Atirar();
            cronometroTiro = 0f; // Reseta o tempo
        }
    }

    void Atirar()
    {
        // Cria o ovo na posição e rotação do ponto de disparo
        Instantiate(ovoPrefab, pontoDeDisparo.position, pontoDeDisparo.rotation);
    }
}