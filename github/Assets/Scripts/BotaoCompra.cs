using UnityEngine;

public class BotaoCompra : MonoBehaviour
{
    public int idSkin = 1;

    // Esta função força a troca para testar
    public void Comprar()
    {
        Debug.Log("🔘 O Botão de Compra FOI CLICADO!");

        // Salva a skin na memória
        PlayerPrefs.SetInt("SkinEquipada", idSkin);
        PlayerPrefs.Save();

        // Procura a galinha
        SkinPlayer galinha = FindFirstObjectByType<SkinPlayer>();

        if (galinha != null)
        {
            Debug.Log("🐔 Galinha encontrada na cena! Tentando mudar o sprite...");
            galinha.AplicarSkinAtual();
        }
        else
        {
            Debug.LogError("❌ ERRO: Nenhuma Galinha com o script 'SkinPlayer' foi encontrada na hierarquia!");
        }
    }
}