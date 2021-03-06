using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MultipleChoice : MonoBehaviour
{
    public GameObject question;
    public GameObject a1button;
    public GameObject a2button;
    public GameObject a3button;
    public GameObject a4button;
    public GameObject a1text;
    public GameObject a2text;
    public GameObject a3text;
    public GameObject a4text;

    public GameObject score;

    public GameObject finishText;
    public GameObject finishCanvas;

    public GameObject questionCanvas;

    private GameObject[] answerTextArr = new GameObject[4];
    private GameObject[] answerButtonArr = new GameObject[4];


    private Quiz quiz = new Quiz();


    public void ButtonOnClick()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        GameObject curButton = EventSystem.current.currentSelectedGameObject;

        // if answer incorrect color button red
        if (!curButton.GetComponent<MonoAnswer>().Correct)
        {
            curButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            // we color the button green below
            // only increment our score
            quiz.incrementCorrect();
        }

        score.GetComponent<Text>().text = quiz.getScore();

        // for all correct answer color them green
        // also disable buttons so that they cannot be clicked
        // this is need because the wait is async and we need to prevent people fromn clicking while waiting
        foreach (GameObject button in answerButtonArr)
        {
            if (button.GetComponent<MonoAnswer>().Correct)
            {
                button.GetComponent<Image>().color = Color.green;
            }
            button.GetComponent<Button>().enabled = false;

        }

        // wait 2 seconds before displaying the next question
        StartCoroutine(WaitBeforeShowingNextQuestion());
    }

    public void nextQuestion()
    {
        // reset buttons
        foreach (GameObject button in answerButtonArr)
        {
            button.GetComponent<Image>().color = Color.white;
            button.GetComponent<Button>().enabled = true;
        }

        Question f = quiz.nextQuestion();
        if (f == null)
        {
            questionCanvas.SetActive(false);
            finishCanvas.SetActive(true);
            finishText.GetComponent<Text>().text = quiz.getFinishMessage();
            return;
        }

        question.GetComponent<Text>().text = f.Text;
        for (int i = 0; i < 4; i++)
        {
            answerTextArr[i].GetComponent<Text>().text = f.Answers[i].Text;
            // Important before setting the answer we have to remove the old one;
            // If we do not do this it will keep using the old answer thus diplaying the wrong correct one.
            Destroy(answerButtonArr[i].GetComponent<MonoAnswer>());
            MonoAnswer answer = answerButtonArr[i].AddComponent<MonoAnswer>();
            answer.Correct = f.Answers[i].Correct;
        }
    }


    void Awake()
    {
        // initilize array
        answerTextArr[0] = a1text;
        answerTextArr[1] = a2text;
        answerTextArr[2] = a3text;
        answerTextArr[3] = a4text;

        answerButtonArr[0] = a1button;
        answerButtonArr[1] = a2button;
        answerButtonArr[2] = a3button;
        answerButtonArr[3] = a4button;
    }

    // Start is called before the first frame update
    void Start()
    {
        nextQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // wait 2 seconds before showing the next question
    IEnumerator WaitBeforeShowingNextQuestion()
    {
        yield return new WaitForSeconds(2);
        nextQuestion();
    }
}
