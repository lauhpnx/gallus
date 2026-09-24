using UnityEngine;

public class MovimentoMilho : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f; // Ajuste a velocidade como preferir

    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime, Space.World);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ovo"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if(collision.CompareTag("Player"))
        {
           Destroy(gameObject);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}