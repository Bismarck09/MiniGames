using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    private ChangeAnimal _changeAnimal;
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI hiscoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] public TextMeshProUGUI prizeText;
    [SerializeField] private Button retryButton;

    private Player player;
    private Spawner spawner;

    private float score;
    public float Score => score;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
            
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        _changeAnimal = GetComponent<ChangeAnimal>();
        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles) {
            Destroy(obstacle.gameObject);
        }

        score = 0f;
        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        UpdateHiscore();

    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");

    }

    public void UpdateHiscore()
    {
        int hiscore = PlayerPrefs.GetInt("DinoRecord", 0);

        if (score > hiscore)
        {
            hiscore = Mathf.FloorToInt(score);
            PlayerPrefs.SetInt("DinoRecord", hiscore);
        }

        _changeAnimal.UpdateSprites(hiscore);

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }

}
