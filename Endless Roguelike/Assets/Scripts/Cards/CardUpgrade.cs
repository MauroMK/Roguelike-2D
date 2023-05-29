using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUpgrade : MonoBehaviour
{
    public TMP_Text nameLabel;
    public TMP_Text descriptionLabel;
    public float upgradeAmount;

    public void Setup(Upgrade upgrade)
    {
        nameLabel.text = upgrade.cardName;
        descriptionLabel.text = upgrade.cardDescription;
        upgradeAmount = upgrade.cardPowerLevel;
    }
}
