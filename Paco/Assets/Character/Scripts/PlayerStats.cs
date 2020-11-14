using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStats
{

    //Attributes
    [Range(0, 500)] [SerializeField] public int Strength;
    [Range(0, 500)] [SerializeField] public int Stamina;
    [Range(0, 500)] [SerializeField] public int Health;


    //Progression
    public int EXP;
    public int Level;
    public int GoldCurrency;


    public PlayerStats(Player player)
    {
        Strength = player.Strength;
        Stamina  = player.Stamina;
        Health   = player.Health;

        EXP      = player.EXP;
        Level    = player.Level;
        GoldCurrency = player.GoldCurrency;


    }

}
