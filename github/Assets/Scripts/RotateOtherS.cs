using UnityEngine;

public class RotateOtherS : MonoBehaviour
{

    public int velocidade = 50;

    void Update()
    {
        transform.Rotate(0, -velocidade * Time.deltaTime, 0);
    }
}