using UnityEngine;

public class PenaPerseguidora : MonoBehaviour
{
    [Header("Configurações")]
    public float velocidade = 5f;
    public int dano = 1;
    private Transform alvoGalinha;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            alvoGalinha = player.transform;
        }
        Destroy(gameObject, 5f);
    }

    void Update()
    {
        if (alvoGalinha != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, alvoGalinha.position, velocidade * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colidiu com o Player");
            GalinhaController galinha = collision.GetComponent<GalinhaController>();
            if (galinha != null)
            {
                galinha.TakeDamage(dano);
                galinha.healthBarImage.fillAmount = (float)galinha.life / galinha._lifemax;
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ovo"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}