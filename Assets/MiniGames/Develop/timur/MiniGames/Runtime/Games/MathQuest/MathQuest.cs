using UnityEngine;
using UnityEngine.UI;

public class MathQuest : MonoBehaviour
{

    public Text exampleText;
    public Button[] answerButtons;
    public Text feedbackText;
    public Text score;
    public Text best;
    public float timeDown = 5f;
    public Text timer;
    public Camera camera;
    public float timeRe;
    public string fileName = "score.xml";
    private int record;

    private string correctAnswer;
    private bool isTime;
    
    private int operand1;
    private int operand2;
    
    private void Start()
    {
        timeRe = timeDown;
        isTime = false;
        record = PlayerPrefs.GetInt("MathQuestRecord", int.Parse(best.text));
        best.text = record.ToString();
        
        UpdateTimer();
        GenerateExample();
        
        foreach (Button button in answerButtons)
        {
            button.onClick.AddListener(() => CheckAnswer(button.GetComponentInChildren<Text>().text));
        }
    }

    void GenerateExample()
    {
        // Генерация примера и правильного ответа
        operand1 = Random.Range(1, 11);
        operand2 = Random.Range(1, 11);
        
        string[] operators = new string[] { "+", "-", "*", "/" };
        string randomOperator = operators[Random.Range(0, operators.Length)];

        exampleText.text = operand1 + " " + randomOperator + " " + operand2 + " = ?";

        switch (randomOperator)
        {
            case "+":
                correctAnswer = (operand1 + operand2).ToString();
                break;
            case "-":
                correctAnswer = (operand1 - operand2).ToString();
                break;
            case "*":
                correctAnswer = (operand1 * operand2).ToString();
                break;
            case "/":
                correctAnswer = (operand1 / operand2).ToString();
                break;
        }


        // Генерация случайного индекса для правильного ответа
        int correctAnswerIndex = Random.Range(0, answerButtons.Length);

        // Установка текста на кнопках, одна из них будет с правильным ответом
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if(i == correctAnswerIndex)
            {
                answerButtons[i].GetComponentInChildren<Text>().text = correctAnswer;
            }
            else
            {
                int randomAnswer = Random.Range(1, 30);
                answerButtons[i].GetComponentInChildren<Text>().text = randomAnswer.ToString();
            }
        }
    }

    void CheckAnswer(string answer)
    {
        if (isTime)
        {
            if (answer == correctAnswer)
            {
                score.text = (int.Parse(score.text) + 1).ToString();
                GenerateExample();
                StartTimer();

            }
            else
            {
                ResetTimer();
                GenerateExample();
            }
        }
    }
    
    void Update()
    {
        if (isTime)
        {
        
            if (timeDown > 0)
            {
                timeDown -= Time.deltaTime;
                UpdateTimer();
            
                if (timeDown < 2)
                {

                    Color orange = Color.Lerp(Color.red, Color.yellow, 0.5f);
                    camera.backgroundColor = orange;
                    UpdateTimer();
                }
                
                if (timeDown < 0)
                {
                    StopTimer();
                }
            }
        }
        else {
        
            StopTimer();
        }
    }
    
    void UpdateTimer()
    {
        isTime = true;
        timer.text = Mathf.Round(timeDown).ToString();
    }
    
    void StopTimer()
    {
        timer.text = "Time Out";
        isTime = false;
        if (int.Parse(score.text) > int.Parse(best.text))
        {
            SaveData();
        }
    }
    
    public void StartTimer()
    {
        timeRe = timeDown;
        Color green = Color.Lerp(Color.yellow, Color.blue, 0.3f);
        camera.backgroundColor = green;
        isTime = true;
        timeDown = timeDown + 5;
        UpdateTimer();
    }
    
    public void ResetTimer()
    {
        timeRe = timeDown;
        isTime = true;
        timeDown = timeDown - 5;
        UpdateTimer();
    }
    
    public void SaveData()
    {
        record = int.Parse(score.text);
        if (record > PlayerPrefs.GetInt("MathQuestRecord"))
        {
            PlayerPrefs.SetInt("MathQuestRecord", record);
        }
    }
}