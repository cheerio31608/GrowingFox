
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject AutoPlayer { get; private set; }
    public GameObject Enemy;

    private AutoHealth playerHealthSystem;
    private AutoExp playerExpSystem;
    private int gold;

    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpGaugeSlider;
    [SerializeField] private Slider expGaugeSlider;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private TextMeshProUGUI GoldText;

    private void Awake()
    {
        Instance = this;

        AutoPlayer = GameObject.FindGameObjectWithTag("Player");;

        playerHealthSystem = AutoPlayer.GetComponent<AutoHealth>();
        playerExpSystem = AutoPlayer.GetComponent<AutoExp>();
    }

    void Start()
    {
        gold = 0;
        hpGaugeSlider.value = 1;
        expGaugeSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(Enemy.name + "(Clone)") == null)
        {
            // 프리팹 오브젝트가 존재하지 않으면, 새로운 오브젝트를 생성합니다.
            Instantiate(Enemy);
            Debug.Log(Enemy.name + " 프리팹이 생성되었습니다.");
        }
    }

    public void UpdateHealthUI()
    {
        //hpGaugeSlider.value = playerHealthSystem.health / playerHealthSystem.maxHealth;
        hpGaugeSlider.value -= 0.05f;
    }

    public void UpdateExpUI()
    {
        expGaugeSlider.value = playerExpSystem.curExp / playerExpSystem.maxExp;
    }

    public void UpdateGoldUI()
    {
        GoldText.text = gold.ToString();
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void GetGold()
    {
        gold += 50;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
