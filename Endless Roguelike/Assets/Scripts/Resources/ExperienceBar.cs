using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceBar : MonoBehaviour
{
    public Image experienceBar;
    public TMP_Text levelText;

    public void UpdateExperienceBar(int experience, int experienceToNextLevel, int level)
    {
        float imageFillAmount = (float)experience / (float)experienceToNextLevel;
        experienceBar.fillAmount = imageFillAmount;
        levelText.text = string.Format("{0}/ {1}", experience, experienceToNextLevel);
    }
}
