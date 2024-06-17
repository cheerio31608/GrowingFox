
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject AutoPlayer { get; private set; }

    [SerializeField] private AutoHealth playerHealthSystem;
    [SerializeField] private AutoExp playerExpSystem;

    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpGaugeSlider;
    [SerializeField] private Slider expGaugeSlider;
    [SerializeField] private GameObject gameOverUI;

    private void Awake()
    {
        Instance = this;

        AutoPlayer = GameObject.FindGameObjectWithTag("Player");

        playerHealthSystem = AutoPlayer.GetComponent<AutoHealth>();
        playerExpSystem = AutoPlayer.GetComponent<AutoExp>();
    }

    void Start()
    {
        hpGaugeSlider.value = 1;
        expGaugeSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthUI()
    {
        Debug.Log($"MaxHealth: {playerHealthSystem.maxHealth}");
        Debug.Log($"Health: {playerHealthSystem.health}");
        hpGaugeSlider.value = playerHealthSystem.health / playerHealthSystem.maxHealth;
    }

    public void UpdateExpUI()
    {
        expGaugeSlider.value = playerExpSystem.curExp / playerExpSystem.maxExp;
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    // �������� ��������� ����!
    private void UpdateWaveUI()
    {
        // waveText.text = 
    }

    // ��ư�� ����� �Լ� -> public����!
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ��ư�� ����� �Լ�
    public void ExitGame()
    {
        Application.Quit();
    }
}
