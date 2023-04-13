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

    public int level = 0;
    public int experience = 0;
    public int experienceToNextLevel = 50;

    public void AddExperience (int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            //* Experience enough to level up´
            level++;
            experience -= experienceToNextLevel;
        }
    }

    public int GetLevelNumber()
    {
        return level;
    }

}
