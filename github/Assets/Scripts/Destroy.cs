using UnityEngine;

public class DogObject : MonoBehaviour
{
    void OnMouseDown()
    {
        // Aqui você pode adicionar som, animação, pontuação etc.
        Destroy(gameObject);
    }
}