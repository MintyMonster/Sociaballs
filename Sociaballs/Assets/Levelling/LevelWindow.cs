using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class LevelWindow : MonoBehaviour
{
    public GameObject levelText;
    public GameObject experienceBar;
    private LevelSystem levelSystem;

    private void Awake()
    {
    }

    private void SetExperienceBarSize(float experienceNormalised)
    {
        experienceBar.GetComponent<Image>().fillAmount = experienceNormalised;
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.GetComponent<Text>().text = "" + (levelNumber);
    }

    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExperienceBarSize(levelSystem.GetExperienceNormalised());

        levelSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        SetExperienceBarSize(levelSystem.GetExperienceNormalised());
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevelNumber(levelSystem.GetLevelNumber());
    }
}
