using System;
using UnityEngine;

public class LevelSystem
{
    private int level;
    private int currentLevel;
    private int experience;
    private int experienceToNextLevel;

    public event EventHandler OnExperienceChanged;
    public event EventHandler OnLevelChanged;


    public LevelSystem()
    {
        level = 1;
        experience = 0;
    }


    public void AddExperience(int amount)
    {
        experience += amount;
        while(experience >= GetExperienceToNextLevel(level))
        {
            experience -= GetExperienceToNextLevel(level);
            level++;
            if (OnLevelChanged != null) OnLevelChanged(this, EventArgs.Empty);
        }
        if (OnExperienceChanged != null) OnExperienceChanged(this, EventArgs.Empty);
    }

    public int GetLevelNumber()
    {
        return level;
    }

    public float GetExperienceNormalised()
    {
        return (float)experience / GetExperienceToNextLevel(level);
    }

    public float GetExperience()
    {
        return experience;
    }

    public int GetExperienceToNextLevel(int level)
    {
        return level * 50;
    }
}
