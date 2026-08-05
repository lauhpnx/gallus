using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    public Sprite spriteNormal;
    public Sprite spriteSkin;
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

        if (skinEquipada == 1)
        {
            sr.sprite = spriteSkin;
            Debug.Log("🎨 Galinha usando: SKIN ESPECIAL");
        }
        else
        {
            sr.sprite = spriteNormal;
            Debug.Log("🐔 Galinha usando: SKIN NORMAL");
        }
    }
}