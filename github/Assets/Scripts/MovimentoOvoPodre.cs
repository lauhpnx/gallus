using UnityEngine;

public class MovimentoOvoPodre : MonoBehaviour
{
    public float velocidade;
    public GalinhaController galinhaController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Se o milho colidir com o Galo, ele se destrói
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            galinhaController.TakeDamage(-1);
        }
    }
}
