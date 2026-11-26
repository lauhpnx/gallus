using UnityEngine;

public class TempoRecorde : MonoBehaviour
{
    public static class TempoRecordeData
    {
        public static float tempoAtual;
        public static bool contando;
        public static TMPro.TextMeshProUGUI tempoText;
    }
    

    // Update is called once per frame
    void Update()
    {
        if (TempoRecordeData.contando)
        {
            TempoRecordeData.tempoAtual += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.T)) 
        {
            TempoRecordeData.contando = !TempoRecordeData.contando;
        }
    }
}
