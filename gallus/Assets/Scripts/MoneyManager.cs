using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    public int dinheiro = 0;
    public TMP_Text textoDinheiro;
    public GameObject Moeda;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
          
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += AoCarregarCena;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= AoCarregarCena;
    }

    void Start()
    {
        AtualizarTexto();
    }

    void AoCarregarCena(Scene cena, LoadSceneMode modo)
    {
        GameObject obj = GameObject.Find("Textodinheiro");
        textoDinheiro = (obj != null) ? obj.GetComponent<TMP_Text>() : null;
        AtualizarTexto();
    }

    public void AdicionarDinheiro(int valor)
    {
        dinheiro += valor;
  
        AtualizarTexto();
    }

    public bool GastarDinheiro(int valor)
    {
        if (dinheiro >= valor)
        {
            dinheiro -= valor;
        
            AtualizarTexto();
            return true;
        }

        return false;
    }

    

    public void AtualizarTexto()
    {
        if (textoDinheiro != null)
        {
            textoDinheiro.text = "$ " + dinheiro;
        }
    }
}