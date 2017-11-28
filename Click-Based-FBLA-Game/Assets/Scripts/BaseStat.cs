﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
    public List<StatBonus> BaseAdditive { get; set; }
    public int BaseVaule { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditive = new List<StatBonus>();
        this.BaseVaule = baseValue;
        this.StatName = statName;
        this.StatName = statDescription;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditive.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditive.Remove(BaseAdditive.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        this.BaseAdditive.ForEach(x => this.FinalValue += x.BonusValue);
        this.FinalValue += BaseVaule;
        return FinalValue;
    }

}
