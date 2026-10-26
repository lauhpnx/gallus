using UnityEngine;
using System.Collections;
public class MovimentoMilho : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    public float morte = 0.5f;
    public GameObject prefabText;
    

    void Update()
    {
        transform.Translate(Vector3.down * velocidade * Time.deltaTime, Space.World);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ovo"))
        {
            if (prefabText != null)
            {
                Instantiate(prefabText, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Player"))
        {
                if (prefabText != null)
                {
                    Instantiate(prefabText, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}