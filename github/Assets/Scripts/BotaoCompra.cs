using UnityEngine;

public class BotaoCompra : MonoBehaviour
{
    public int preco = 95;

    public void Comprar()
    {
        if (MoneyManager.Instance.GastarDinheiro(preco))
        {
            Debug.Log("Item comprado!");
        }
        else
        {
            Debug.Log("Moedas insuficientes!");
        }
    }
}