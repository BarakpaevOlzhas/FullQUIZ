using Assets.MaterialUI.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    List<RootObject> answers = new List<RootObject>();

    private int flex;

    [SerializeField]
    private Transform panelOne;

    [SerializeField]
    private EndGame endGame;

    [SerializeField]
    private Text text;

    [SerializeField]
    private Button buttonTrue;

    [SerializeField]
    private Button buttonFalse;

    private int countOfCorrectAnswers = 0;

    private int max;

    // Start is called before the first frame update
    void Start()
    {
        buttonTrue.onClick.AddListener(ButtonClickForTrue);
        buttonFalse.onClick.AddListener(ButtonClickForFalse);


    }
    public void Init(List<RootObject> rootObjects)
    {
        answers = rootObjects;

        max = answers.Count;

        NextQuestion();
    }
    private int GenerateRandomNumberInQuestions()
    {
        if (answers.Count == 0)
        {
            panelOne.gameObject.SetActive(false);
            buttonFalse.gameObject.SetActive(false);
            buttonTrue.gameObject.SetActive(false);
            endGame.Init("You Win", countOfCorrectAnswers, max);
        }

        System.Random rand = new System.Random();
        return (rand.Next(answers.Count));
    }

    private void NextQuestion()
    {
        flex = GenerateRandomNumberInQuestions();
        text.text = answers[flex].name_ru;
    }
    private void ButtonClickForTrue()
    {
        if (answers[flex].right_answer == true)
        {
            countOfCorrectAnswers++;
            answers.RemoveAt(flex);
            NextQuestion();
        }
        else
        {
            panelOne.gameObject.SetActive(false);
            buttonFalse.gameObject.SetActive(false);
            buttonTrue.gameObject.SetActive(false);
            endGame.Init("You Lose", countOfCorrectAnswers, max);
        }
    }
    private void ButtonClickForFalse()
    {
        if (answers[flex].right_answer == false)
        {
            countOfCorrectAnswers++;
            answers.RemoveAt(flex);
            NextQuestion();
        }
        else
        {
            panelOne.gameObject.SetActive(false);
            buttonFalse.gameObject.SetActive(false);
            buttonTrue.gameObject.SetActive(false);
            endGame.Init("You Lose", countOfCorrectAnswers, max);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        buttonTrue.onClick.RemoveAllListeners();
        buttonFalse.onClick.RemoveAllListeners();
    }
}
