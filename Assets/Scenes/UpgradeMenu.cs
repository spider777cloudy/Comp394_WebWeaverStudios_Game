using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    [SerializeField] private Stats stats;

    public Text slimePointsText;
    public Text healthPointsText;
    public Text manaPointsText;
    public Text powerPointsText;

    private void Update()
    {
        stats.UpdateAttributes();
        UpdateUI();
    }

    private void UpdateUI()
    {
        slimePointsText.text = stats.slimePoints.ToString();
        healthPointsText.text = stats.vitalityScore.ToString();
        manaPointsText.text = stats.arcaneScore.ToString();
        powerPointsText.text = stats.strengthScore.ToString();
    }

    public void IncreaseHealth()
    {
        if (stats.slimePoints > 0)
        {
            stats.slimePoints--;
            stats.vitalityScore++;

            UpdateUI();
        }
    }

    public void DecreaseHealth() 
    {
        if (stats.vitalityScore > 0)
        {
            stats.vitalityScore--;
            stats.slimePoints++;

            UpdateUI();
        }
    }

    public void IncreaseMana() 
    {
        if (stats.slimePoints > 0)
        {
            stats.slimePoints--;
            stats.arcaneScore++;

            UpdateUI();
        }
    }

    public void DecreaseMana() 
    {
        if (stats.arcaneScore > 0)
        {
            stats.arcaneScore--;
            stats.slimePoints++;

            UpdateUI();
        }
    }

    public void IncreasePower()
    {
        if (stats.slimePoints > 0)
        {
            stats.slimePoints--;
            stats.strengthScore++;

            UpdateUI();
        }
    }

    public void DecreasePower()
    {
        if (stats.strengthScore > 0)
        {
            stats.strengthScore--;
            stats.slimePoints++;

            UpdateUI();
        }
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
