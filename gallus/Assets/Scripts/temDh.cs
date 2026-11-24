using UnityEngine;
using TMPro;

public class temDh : MonoBehaviour
{
    public static temDh Instance;
    public MoneyManager moneyManager;
    //public int dinhero = 0;
    public TMP_Text textoDinhero;
    public void Start()
    {
        textoDinhero.gameObject.SetActive(false);
    }
    public void Comprar()
    {
        if (moneyManager.dinheiro <= 99)
        {
            Instantiate(moneyManager);
            textoDinhero.gameObject.SetActive(true);
        }
    }
}

