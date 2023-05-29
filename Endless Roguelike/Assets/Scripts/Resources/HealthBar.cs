using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public TMP_Text healthText;

    public void UpdateHealthBar(float health, float maxHealth)
    {
        float imageFillAmount = health / maxHealth;
        healthBar.fillAmount = imageFillAmount;
        healthText.text = string.Format("{0}/ {1}", health, maxHealth);  // string.Format passa para text, {0} / {1} é para separar os dois numeros por uma barra no meio
    }
}
