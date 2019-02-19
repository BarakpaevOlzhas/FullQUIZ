using Assets.MaterialUI.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    private Text textSource;

    [SerializeField]
    private Button buttonExit;

    [SerializeField]
    private Text titleText;

    [SerializeField]
    private Transform root;


    void Start()
    {
        buttonExit.onClick.AddListener(ButtonClickExit);

                
    }

    public void Init(string title, int curScore, int maxQ)
    {
        root.gameObject.SetActive(true);

        titleText.text = title;

        textSource.text = curScore.ToString() + "/" + maxQ.ToString();        
    }


    void ButtonClickExit()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
