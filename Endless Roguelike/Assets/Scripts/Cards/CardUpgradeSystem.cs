using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUpgradeSystem : MonoBehaviour
{
    public List<GameObject> upgradeCardPrefabs; // Prefabs das cartas de upgrade
    public int numUpgradesToShow; // Número de upgrades para exibir ao jogador

    private List<Upgrade> currentUpgrades; // Lista de upgrades atuais

    private void Start()
    {
        currentUpgrades = new List<Upgrade>();
    }

    // Função chamada quando o jogador alcança um novo nível
    public void GenerateUpgrades()
    {
        // Limpa a lista de upgrades atuais
        currentUpgrades.Clear();

        // Gera upgrades aleatórios
        for (int i = 0; i < numUpgradesToShow; i++)
        {
            Upgrade randomUpgrade = GetRandomUpgrade();
            currentUpgrades.Add(randomUpgrade);
        }

        // Exibe as cartas de upgrade na tela
        DisplayUpgrades(currentUpgrades);
    }

    // Função para selecionar um upgrade
    public void SelectUpgrade(Upgrade selectedUpgrade)
    {
        // Aplica o upgrade selecionado
        ApplyUpgrade(selectedUpgrade);

        // Remove as cartas de upgrade da tela
        HideUpgrades();

        // Despausa o jogo
        Time.timeScale = 1f;
    }

    // Função para obter um upgrade aleatório da lista de upgrades disponíveis
    private Upgrade GetRandomUpgrade()
    {
        int randomIndex = Random.Range(0, upgradeCardPrefabs.Count);
        GameObject upgradeCardPrefab = upgradeCardPrefabs[randomIndex];
        CardUpgrade upgradeCard = upgradeCardPrefab.GetComponent<CardUpgrade>();

        Upgrade upgrade = new Upgrade();
        upgrade.cardName = upgradeCard.nameLabel.text;
        upgrade.cardDescription = upgradeCard.descriptionLabel.text;
        upgrade.cardPowerLevel = upgradeCard.upgradeAmount;

        return upgrade;
    }

    // Função para exibir as cartas de upgrade na tela
    private void DisplayUpgrades(List<Upgrade> upgrades)
    {
        // Exibe as cartas de upgrade na tela
        for (int i = 0; i < upgrades.Count; i++)
        {
            GameObject upgradeCardPrefab = upgradeCardPrefabs[i];
            GameObject upgradeCardObject = Instantiate(upgradeCardPrefab, transform);
            CardUpgrade upgradeCard = upgradeCardObject.GetComponent<CardUpgrade>();
            upgradeCard.Setup(upgrades[i]);
        }
    }

    // Função para aplicar o upgrade selecionado
    private void ApplyUpgrade(Upgrade upgrade)
    {
        // Implemente a lógica para aplicar o efeito do upgrade selecionado
        // Por exemplo, atualizar as propriedades do jogador ou do jogo com base no upgrade selecionado
    }

    // Função para remover as cartas de upgrade da tela
    private void HideUpgrades()
    {
        // Remove todas as cartas de upgrade da tela
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}

[System.Serializable]
public class Upgrade
{
    public string cardName;
    public string cardDescription;
    public float cardPowerLevel;
    // Outros atributos relevantes para o upgrade
}
