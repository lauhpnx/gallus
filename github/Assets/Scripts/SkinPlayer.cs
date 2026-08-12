using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    [Header("Sprites das Galinhas")]
    public Sprite spriteNormal; // 0
    public Sprite spriteSkin;   // 1
    public Sprite sprite3;      // 2

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        AplicarSkinAtual();
    }

    public void AplicarSkinAtual()
    {
        if (sr == null) sr = GetComponent<SpriteRenderer>();

        int skinEquipada = PlayerPrefs.GetInt("SkinEquipada", 0);

        if (skinEquipada == 2)
        {
            sr.sprite = sprite3;
            Debug.Log("🎨 Galinha usando: SKIN CHEFE (TIPO 3)");
        }
        else if (skinEquipada == 1)
        {
            sr.sprite = spriteSkin;
            Debug.Log("🎨 Galinha usando: SKIN ESPECIAL (TIPO 1)");
        }
        else
        {
            sr.sprite = spriteNormal;
            Debug.Log("🐔 Galinha usando: SKIN NORMAL (TIPO 0)");
        }
    }
}