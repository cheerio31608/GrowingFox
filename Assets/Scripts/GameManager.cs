
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
            // ������ ������Ʈ�� �������� ������, ���ο� ������Ʈ�� �����մϴ�.
            Instantiate(Enemy);
            Debug.Log(Enemy.name + " �������� �����Ǿ����ϴ�.");
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
