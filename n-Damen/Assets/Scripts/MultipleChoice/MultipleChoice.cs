using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MultipleChoice : MonoBehaviour
{
    public GameObject frage;
    public GameObject a1button;
    public GameObject a2button;
    public GameObject a3button;
    public GameObject a4button;
    public GameObject a1text;
    public GameObject a2text;
    public GameObject a3text;
    public GameObject a4text;

    private GameObject[] antwortTextArr = new GameObject[4];
    private GameObject[] antwortButtonArr = new GameObject[4];


    private Fragen fragen = new Fragen();

    private GameObject korekteAntwort;


    public void ButtonOnClick()
    {
        StartCoroutine(WaitSeconds(2));
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        GameObject curButton = EventSystem.current.currentSelectedGameObject;

        // wenn falsche antwort macd den button rot
        if (!curButton.GetComponent<MonoAntwort>().Richtig)
        {
            curButton.GetComponent<Image>().color = Color.red;
        }

        // f?r richtige antwort soll gr?n sein egal welcher button gedr?ckt wurde
        foreach (GameObject button in antwortButtonArr)
        {
            if (button.GetComponent<MonoAntwort>().Richtig)
            {
                button.GetComponent<Image>().color = Color.green;
            }
            button.GetComponent<Button>().enabled = false;

        }
    }

    public void naechsteFrage()
    {
        // reset buttons
        foreach (GameObject button in antwortButtonArr)
        {
            button.GetComponent<Image>().color = Color.white;
            button.GetComponent<Button>().enabled = true;
        }

        Frage f = fragen.naechsteFrage();
        if (f == null)
        {
            // TODO ende
            return;
        }
        frage.GetComponent<Text>().text = f.Text;
        for (int i = 0; i < 4; i++)
        {
            antwortTextArr[i].GetComponent<Text>().text = f.Antworten[i].Text;
            MonoAntwort antwort = antwortButtonArr[i].AddComponent<MonoAntwort>();
            antwort.Richtig = f.Antworten[i].Richtig;
        }
    }


    void Awake()
    {
        // initilize array
        antwortTextArr[0] = a1text;
        antwortTextArr[1] = a2text;
        antwortTextArr[2] = a3text;
        antwortTextArr[3] = a4text;

        antwortButtonArr[0] = a1button;
        antwortButtonArr[1] = a2button;
        antwortButtonArr[2] = a3button;
        antwortButtonArr[3] = a4button;
    }

    // Start is called before the first frame update
    void Start()
    {
        naechsteFrage();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Warte 2 sekunden und dann schaue die n?chste Frage
    IEnumerator WaitSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        naechsteFrage();
    }
}
