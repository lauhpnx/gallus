using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float velocidade = 200f;

    void Update()
    {
        transform.Rotate(0, 0, velocidade * Time.deltaTime);
    }
}
