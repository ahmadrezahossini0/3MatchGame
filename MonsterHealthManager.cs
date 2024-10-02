using UnityEngine.UI;
using UnityEngine;

public class MonsterHealthManager : MonoBehaviour,IstHealthObjects
{
  
  [SerializeField] private float monsterHealth;
 
    private Monster monster;
    private IUiPrints uiManager;
    private bool _dispose;

    void Awake()
    {
        monster = FindObjectOfType<Monster>();
        monsterHealth = monster.MonsterHealth;
        uiManager = FindObjectOfType<UiManager>();
        ShowHealth(uiManager.printMonsterHealth());
    }

    public void DecreaseHealth(short NumberDamage)
    {
        monsterHealth -= NumberDamage;
        ShowHealth(uiManager.printMonsterHealth());
    }

    public float ShowHealth(Text txtHealthmonster)
    {
        txtHealthmonster.text = monsterHealth.ToString();
        return monsterHealth;
    }

  

  








}
