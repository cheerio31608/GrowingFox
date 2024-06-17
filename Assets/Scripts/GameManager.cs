
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private AutoHealth playerHealthSystem;

    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpGaugeSlider;
    [SerializeField] private Slider expGaugeSlider;
    [SerializeField] private GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        expGaugeSlider.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateHealthUI()
    {
        hpGaugeSlider.value = playerHealthSystem.health / playerHealthSystem.maxHealth;
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    // 스테이지 진행로직에 얹어요!
    private void UpdateWaveUI()
    {
        // waveText.text = 
    }

    // 버튼에 연결될 함수 -> public으로!
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 버튼에 연결될 함수
    public void ExitGame()
    {
        Application.Quit();
    }
}
