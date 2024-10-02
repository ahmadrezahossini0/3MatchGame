using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterMonster : Monster
{
    private LerpSlides _lerpslider;
   private IstHealthObjects MonsterHealth;

    private void Awake()
    {
        _lerpslider = FindObjectOfType<LerpSlides>();
        MonsterHealth =FindObjectOfType<MonsterHealthManager>();
       StartCoroutine(_lerpslider.Ienum_lerpTime(AttackTime));
    }

    public override void reciveDamage(string ElementName)
    {
        if (ElementName.Contains("blue")) 
        {
            MonsterHealth.DecreaseHealth(30);
            return;
        }

        MonsterHealth.DecreaseHealth(15);








    }
}
