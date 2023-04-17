using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    void Awake() 
    {
        instance = this;
    }
    
    #endregion

    public Player player;
    public ExperienceBar experienceBar;

    public int level = 1;
    public int experience = 0;
    public int experienceToNextLevel = 50;
    private int increaseXP = 20;

    void Start()
    {
        experienceBar.UpdateExperienceBar(experience, experienceToNextLevel, level);
    }

    public void AddExperience (int amount)
    {
        experience += amount;

        if (experience >= experienceToNextLevel)
        {
            //* Experience enough to level up´
            OnLevelUp();
        }

        experienceBar.UpdateExperienceBar(experience, experienceToNextLevel, level);
    }

    void OnLevelUp()
    {
        level++;
        experience -= experienceToNextLevel;
        experienceToNextLevel += increaseXP;
        //TODO Show 3 upgrades on the screen
    }

    void ShowUpgradesOnScreen()
    {
        // Pop up 3 cards with the upgrades
        // certain upgrades modify the Bullet.cs
        // others modify hp or speed of the player.cs
        
    }

}
