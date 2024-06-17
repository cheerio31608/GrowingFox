
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
