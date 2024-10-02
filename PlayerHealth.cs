using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IstHealthObjects
{
   [SerializeField] private float Health;
    HealthObjectCaller initiateHealth;
    private IUiPrints uiManager;

    private bool _dispose;

    void Awake() 
    {

        uiManager = FindObjectOfType<UiManager>();
        ShowHealth(uiManager.PrintPlayerHealth());
       

       
       
    }

    public void DecreaseHealth(short NumberDamage)
    {
        float healthbeforattack = Health;
        Health -= NumberDamage;
        ShowHealth(uiManager.PrintPlayerHealth());
    }

    public float ShowHealth( Text txtHealthObject)
    {
        
        txtHealthObject.text = Health.ToString();
        return Health;

    }


   
   

}
