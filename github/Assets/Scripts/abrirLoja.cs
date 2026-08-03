using UnityEngine;

public class abrirLoja : MonoBehaviour
{
    [Header("UI de Vitória")]
    public GameObject Loja;
    [Header("UI de Vitória")]
    public GameObject painelCreditos;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (Loja != null)
            {
                Loja.SetActive(false);
            }
            if (painelCreditos != null)
            {
                painelCreditos.SetActive(false);
            }
        }
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (painelCreditos != null)
            {
                painelCreditos.SetActive(false);
            }
            if (Loja != null)
            {
                Loja.SetActive(false);
            }
        }
    }
    public void AbrirLoja()
    {
        if (Loja != null)
        {
            Loja.SetActive(true);
        }
        Time.timeScale = 0f;
    }
    public void fecharLoja()
    {
        if (Loja != null)
        {
            Loja.SetActive(false);
        }
        Time.timeScale = 1f;
    }
}