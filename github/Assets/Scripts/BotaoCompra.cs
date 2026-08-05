using UnityEngine;

public class BotaoCompra : MonoBehaviour
{
    [Header("Configurações do Item")]
    public int preco = 95; 
    public int idSkin = 1; 

    public void Comprar()
    {
        Debug.Log("🔘 Botão de compra clicado!");
        if (idSkin == 0)
        {
            Equipar();
            return;
        }
        if (PlayerPrefs.GetInt("SkinComprada_" + idSkin, 0) == 1)
        {
            Equipar();
            return;
        }
        if (MoneyManager.Instance != null && MoneyManager.Instance.GastarDinheiro(preco))
        {
            PlayerPrefs.SetInt("SkinComprada_" + idSkin, 1); 
            Equipar();
            Debug.Log("✅ Skin comprada e equipada!");
        }
        else
        {
            Debug.Log("❌ Dinheiro insuficiente ou MoneyManager não encontrado!");
        }
    }

    void Equipar()
    {
        PlayerPrefs.SetInt("SkinEquipada", idSkin);
        PlayerPrefs.Save();

        SkinPlayer galinha = FindFirstObjectByType<SkinPlayer>();
        if (galinha != null)
        {
            galinha.AplicarSkinAtual();
            Debug.Log("🎨 Skin alterada com sucesso na tela!");
        }
        else
        {
            Debug.LogWarning("⚠️ Nenhuma galinha encontrada com o script SkinPlayer!");
        }
    }
}