using UnityEngine;

public class BotaoCompra : MonoBehaviour
{
    [Header("Configurações do Item")]
    public int preco = 95;
    public int idSkin = 1;

    public void Comprar()
    {
        Debug.Log("🔘 Botão de compra clicado para ID: " + idSkin);

        // Se for a Skin 0 (Padrão), só equipa
        if (idSkin == 0)
        {
            Equipar();
            return;
        }

        // Se já foi comprada anteriormente, só equipa
        if (PlayerPrefs.GetInt("SkinComprada_" + idSkin, 0) == 1)
        {
            Equipar();
            return;
        }

        // Tenta comprar com o dinheiro do jogador
        if (MoneyManager.Instance != null && MoneyManager.Instance.GastarDinheiro(preco))
        {
            PlayerPrefs.SetInt("SkinComprada_" + idSkin, 1);
            Equipar();
            Debug.Log("✅ Skin " + idSkin + " comprada e equipada!");
        }
        else
        {
            Debug.Log("❌ Dinheiro insuficiente ou MoneyManager não encontrado!");
        }
    }

    void Equipar()
    {
        // 1. Grava a skin equipada na memória permanente
        PlayerPrefs.SetInt("SkinEquipada", idSkin);
        PlayerPrefs.Save(); // Força o salvamento imediato no arquivo de dados!

        Debug.Log("💾 Skin ID " + idSkin + " salva no PlayerPrefs!");

        // 2. Se a galinha existir na cena atual (ex: na loja), atualiza a imagem
        SkinPlayer galinha = FindFirstObjectByType<SkinPlayer>();
        if (galinha != null)
        {
            galinha.AplicarSkinAtual();
            Debug.Log("🎨 Skin alterada com sucesso na tela!");
        }
    }
}