using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public float velocidade = 50f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * velocidade * Time.deltaTime);
    }
}
