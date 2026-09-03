using System.Collections;
using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    [Header("Sprites das Galinhas — específicos desta fase")]
    public Sprite spriteNormal;
    public Sprite spriteSkin;
    public Sprite sprite3;
    public GalinhaController galinhaController;

    public int skinEquipada = 0; // sempre começa do zero ao carregar a cena

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        AplicarSkinAtual();
        galinhaController = GetComponent<GalinhaController>();
    }

    public void EquiparSkin(int idSkin)
    {
        skinEquipada = idSkin;
        AplicarSkinAtual();
    }

    public void AplicarSkinAtual()
    {
        switch (skinEquipada)
        {
            case 2: if (sprite3 != null) sr.sprite = sprite3; break;
            case 1: if (spriteSkin != null) sr.sprite = spriteSkin;
                galinhaController.DefinirTipoDeTiro(2);
                break;
            default: if (spriteNormal != null) sr.sprite = spriteNormal; break;
        }
    }
}