using UnityEngine;

public class MovimentoOvoPodre : MonoBehaviour
{
    public float velocidade;
    public GalinhaController galinhaController;
    public int damage = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            GalinhaController galinha = collision.GetComponent<GalinhaController>();
            if (galinha != null)
            {
                galinha.TakeDamage(damage);
            }

        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
