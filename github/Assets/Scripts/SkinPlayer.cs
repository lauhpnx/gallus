using UnityEngine;

public class SkinPlayer : MonoBehaviour
{
    public Sprite spriteNormal;
    public Sprite spriteSkin;

    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (PlayerPrefs.GetInt("SkinEquipada", 0) == 1)
        {
            sr.sprite = spriteSkin;
        }
        else
        {
            sr.sprite = spriteNormal;
        }
    }
}