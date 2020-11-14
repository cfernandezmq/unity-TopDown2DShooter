using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Attributes
    [Range(0, 500)] [SerializeField] public int Health = 100;
    [Range(0, 500)] [SerializeField] public int Strength = 5;
    [Range(0, 500)] [SerializeField] public int Stamina = 10;

    //Progression
    [SerializeField] public int EXP = 0;
    [SerializeField] public int Level = 1;
    [SerializeField] public int GoldCurrency = 0;
    [SerializeField] public int SkillPoints = 0;

    //Gameplay Related
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int EXPRequiredToLevel;

    // Start is called before the first frame update
    void Start()
    {
        EXPRequiredToLevel = Level * 100;
    }

    public void SaveCharacterStats()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadCharacterStats()
    {
        PlayerStats stats = SaveSystem.LoadPlayer();
        Strength = stats.Strength;
        Stamina  = stats.Stamina;
        Health   = stats.Health;

        EXP      = stats.EXP;
        Level    = stats.Level;

        maxHealth = Stamina * 10;
        GoldCurrency = stats.GoldCurrency;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveEXP(int AwardedEXP)
    {
        if ((EXP + AwardedEXP) >= EXPRequiredToLevel)
        {
            EXP = (-((EXPRequiredToLevel - EXP) - AwardedEXP));
            ++Level;
            ++SkillPoints;
            EXPRequiredToLevel = Level * 100;

        }
        else
        {
            EXP += AwardedEXP;
        }
    }
}
