using UnityEngine;

public class TempoRecorde : MonoBehaviour
{
    public static class TempoRecordeData
    {
        public static float tempoAtual;
        public static bool contando;
        public static TMPro.TextMeshProUGUI tempoText;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TempoRecordeData.contando)
        {
            TempoRecordeData.tempoAtual += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.T)) //mostra a contagem
        {
            TempoRecordeData.contando = !TempoRecordeData.contando;
        }
    }
}
