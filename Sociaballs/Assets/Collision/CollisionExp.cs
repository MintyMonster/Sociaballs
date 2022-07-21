using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollisionExp : MonoBehaviour
{
    public GameObject levelup;
    public GameObject experienceBar;
    public GameObject levelText;
    public GameObject controller;
    public GameObject upgrade;
    public GameObject adsPanel;
    public GameObject profilePanel;
    public GameObject profile;

    public static bool likesActive;
    public static bool followersActive;
    public static bool reactionsActive;
    public static bool badActive;
    public static bool goodActive;
    public static bool adsActive;
    public static bool viewsActive = true;

    public static bool doubleCash = false;

    public static bool adsOpen = false;

    private long viewsWorth;
    private long likesWorth;
    private long followsWorth;
    private long reactionsWorth;
    private long goodWorth;
    private long badWorth;
    public long badTapWorth;

    public static long adsWorth;


    LevelSystem levelSystem = new LevelSystem();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ViewsBall")
        {
            //Debug.Log(levelSystem.GetExperience());
            //Debug.Log(levelSystem.GetLevelNumber());
            levelSystem.AddExperience(10);
            SetLevelSystem(levelSystem);
            controller.GetComponent<Currency>().addDollars(viewsWorth);
            profilePanel.GetComponent<profileStats>().addTotalViews(1);
            CombatTextManager.Instance.CreateText(collision.gameObject.transform.position, $"+${viewsWorth}", Color.green, true);
        }

        if(collision.gameObject.tag == "LikesBall")
        {
            levelSystem.AddExperience(15);
            SetLevelSystem(levelSystem);
            controller.GetComponent<Currency>().addDollars(likesWorth);
            profilePanel.GetComponent<profileStats>().addTotalLikes(1);
            CombatTextManager.Instance.CreateText(collision.gameObject.transform.position, $"+${likesWorth}", Color.green, true);
        }

        if(collision.gameObject.tag == "FollowersBall")
        {
            levelSystem.AddExperience(25);
            SetLevelSystem(levelSystem);
            controller.GetComponent<Currency>().addDollars(followsWorth);
            profilePanel.GetComponent<profileStats>().addTotalFollows(1);
            CombatTextManager.Instance.CreateText(collision.gameObject.transform.position, $"+${followsWorth}", Color.green, true);
        }

        if(collision.gameObject.tag == "ReactionsBall")
        {
            levelSystem.AddExperience(30);
            SetLevelSystem(levelSystem);
            controller.GetComponent<Currency>().addDollars(reactionsWorth);
            profilePanel.GetComponent<profileStats>().addTotalReactions(1);
            CombatTextManager.Instance.CreateText(collision.gameObject.transform.position, $"+${reactionsWorth}", Color.green, true);
        }

        if(collision.gameObject.tag == "hateBall")
        {
            SetLevelSystem(levelSystem);
            controller.GetComponent<Currency>().removeDollars(badWorth);
            if (controller.GetComponent<Currency>().getDollars() < 0)
            {
                controller.GetComponent<Currency>().setDollars(0);
            }
            profilePanel.GetComponent<profileStats>().addTotalBad(1);
            CombatTextManager.Instance.CreateText(collision.gameObject.transform.position, $"-${badWorth}", Color.red, true);
        }

        if(collision.gameObject.tag == "GoodCommentsBall")
        {
            levelSystem.AddExperience(40);
            SetLevelSystem(levelSystem);
            controller.GetComponent<Currency>().addDollars(goodWorth);
            profilePanel.GetComponent<profileStats>().addTotalGood(1);
            CombatTextManager.Instance.CreateText(collision.gameObject.transform.position, $"+${goodWorth}", Color.green, true);
        }
        
        if(collision.gameObject.tag == "AdvertsBall")
        {
            adShow();
            SetLevelSystem(levelSystem);
        }
    }

    private void Update()
    {
        if (levelSystem.GetLevelNumber() >= 5) likesActive = true;
        if (levelSystem.GetLevelNumber() >= 10) followersActive = true;
        if (levelSystem.GetLevelNumber() >= 15) reactionsActive = true;
        if (levelSystem.GetLevelNumber() >= 20) goodActive = true;
        if (levelSystem.GetLevelNumber() >= 25) badActive = true;

        if (doubleCash)
        {
            viewsWorth = 16 * levelSystem.GetLevelNumber();
            likesWorth = 24 * levelSystem.GetLevelNumber();
            followsWorth = 32 * levelSystem.GetLevelNumber();
            reactionsWorth = 44 * levelSystem.GetLevelNumber();
            goodWorth = 80 * levelSystem.GetLevelNumber();
            badWorth = 200 * levelSystem.GetLevelNumber();
            badTapWorth = 200 * levelSystem.GetLevelNumber();
            adsWorth = 4000 * levelSystem.GetLevelNumber();
        }
        else
        {
            viewsWorth = 8 * levelSystem.GetLevelNumber();
            likesWorth = 12 * levelSystem.GetLevelNumber();
            followsWorth = 16 * levelSystem.GetLevelNumber();
            reactionsWorth = 22 * levelSystem.GetLevelNumber();
            goodWorth = 40 * levelSystem.GetLevelNumber();
            badWorth = 200 * levelSystem.GetLevelNumber();
            badTapWorth = 100 * levelSystem.GetLevelNumber();

            adsWorth = 2000 * levelSystem.GetLevelNumber();
        }

        
    }


    public bool getDoubleCashState()
    {
        return doubleCash;
    }

    public void setDoubleCashState(bool b)
    {
        doubleCash = b;
    }
    public long getBadTapWorth()
    {
        return badTapWorth;
    }

    private void Start()
    {
    }

    public long getAdsWorth()
    {
        return adsWorth;
    }

    void adShow()
    {
        if (upgrade.GetComponent<upgradeButton>().getState() == true)
        {
            upgrade.GetComponent<upgradeButton>().upgradeHide();
            adsPanel.gameObject.SetActive(true);
        }
        else if(profile.GetComponent<profileButton>().getProfileState() == true)
        {
            profile.GetComponent<profileButton>().profileHide();
            adsPanel.gameObject.SetActive(true);
        }
        else
        {
            adsPanel.gameObject.SetActive(true);
        }
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
        levelup.GetComponent<levelUpParticles>().startParticles();
    }
}
