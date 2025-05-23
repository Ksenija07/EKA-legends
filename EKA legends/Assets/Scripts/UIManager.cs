using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image healthGlobe, manaGlobe;
    [SerializeField] private Slider xpSlider;
    [SerializeField] private PLayerHealth pLayerHealth;
    [SerializeField] private GameObject levelCompleteMenu;
    private int currentXP = 0;
    private int maxXP = 100;
    private int levelCount = 0;
    private int maxLevels = 2;
    void Start()
    {
        xpSlider.maxValue = maxXP;
        xpSlider.value = currentXP;
    }

    public void AddXP(int amount)
    {
        currentXP += amount;

        if (currentXP >= maxXP)
        {
            levelCount++;
            currentXP = 0;      

            if (levelCount >= maxLevels)
            {
                ShowLevelCompleteMenu();
            }
            else
            {
                Debug.Log("Level up! Current level: " + (levelCount + 1));
            }
        }

        xpSlider.value = currentXP;
    }
    private void ShowLevelCompleteMenu()
    {
        levelCompleteMenu.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {
        healthGlobe.fillAmount = pLayerHealth.GetHealthRatio();
        manaGlobe.fillAmount = pLayerHealth.GetManaRatio();
    }
}
