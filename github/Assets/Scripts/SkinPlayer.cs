using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    [Header("Sprites das Galinhas")]
    public Sprite spriteNormal; // ID 0
    public Sprite spriteSkin;   // ID 1
    public Sprite sprite3;      // ID 2
    private int skinEquipada = 0;
    private SpriteRenderer sr;

    void Start()
    {
        AplicarSkinAtual();
        SkinPlayer skinPlayer = GetComponent<SkinPlayer>();
        if (skinPlayer != null)
        {
            skinPlayer.AplicarSkinAtual();
        }
        else
        {
            Debug.LogError("⚠️ O script 'SkinPlayer' NÃO está anexado neste GameObject da Galinha!");
        }

    }

    public void AplicarSkinAtual()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();

       
        int skinEquipada = PlayerPrefs.GetInt("SkinEquipada", 0);

        if (skinEquipada == 2)
        {
            if (sprite3 != null) sr.sprite = sprite3;
            Debug.Log("🎨 Galinha usando: SKIN CHEFE (TIPO 2)");
        }
        else if (skinEquipada == 1)
        {
            if (spriteSkin != null) sr.sprite = spriteSkin;
            Debug.Log("🎨 Galinha usando: SKIN ESPECIAL (TIPO 1)");
        }
        else
        {
            if (spriteNormal != null) sr.sprite = spriteNormal;
            Debug.Log("🐔 Galinha usando: SKIN NORMAL (TIPO 0)");
        }
    }
}