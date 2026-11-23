using UnityEngine;

public class ItensLoja : MonoBehaviour
{
    public GalinhaController galinhaController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void ComprarItem1()
    {
      galinhaController.velocidadeMovimento += 1f;
    }
}
