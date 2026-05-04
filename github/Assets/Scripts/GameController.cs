using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    public int foundedObj;
    public int objtsNumber;
    public UnityEvent OnVictory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objtsNumber = transform.childCount;


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FoundCat()
    {
        //Esta linha é apenas para programadores
        //founded objects = foundedobjects + 1;
        foundedObj += 1;
        if (foundedObj >= objtsNumber)
        {
            OnVictory.Invoke();
        }

        //founded objects++;
    }
}
