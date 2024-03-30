
using UnityEngine;


public class ChangeAnimal : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject[] Animals = new GameObject[3];
    [SerializeField] private GameObject[] AnimalsChose = new GameObject[3];
    [SerializeField] private GameObject[] AnimalsUI = new GameObject[3];
    private int firstUnlock = 150;
    private int secondUnlock = 350;
    int savedAnimal;

    private void Start()
    {
        savedAnimal = PlayerPrefs.GetInt("choosenAnimal");
        ChangeAnimalFunc(savedAnimal);
    }

    public void UpdateSprites(float hiscore)
    {
        if (hiscore < firstUnlock)
            gameManager.prizeText.text = Mathf.FloorToInt(firstUnlock).ToString("D5");
        if (hiscore >= firstUnlock)
        {
            AnimalsUI[1].SetActive(true);
            gameManager.prizeText.text = Mathf.FloorToInt(secondUnlock).ToString("D5");
        }
        if (hiscore >= secondUnlock)
        {
            AnimalsUI[2].SetActive(true);
            gameManager.prizeText.text = "All animals unlocked!";
        }


        
    }


    public void ChangeAnimalFunc(int needNumber)
    {
        Animals[needNumber].SetActive(true);
        AnimalsChose[needNumber].SetActive(true);

        for (int i = 0; i < Animals.Length; i++)
        {
            if (needNumber != i)
            {
                Animals[i].SetActive(false);
                AnimalsChose[i].SetActive(false);
            }
        }

        PlayerPrefs.SetInt("choosenAnimal", needNumber);
    }
}
