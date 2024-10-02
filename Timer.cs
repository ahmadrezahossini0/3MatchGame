using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    IUiPrints _uimanager;
    IUiPanels _uiPanels;
    IHighScoremethodes highscore_savedata;
    IUiAnimation uiAnimation;
    GenerateGlass _generateGlass;
    WaitForSeconds oneSecond;

    public byte secondTime;

    private void Awake()
    {
        oneSecond = new WaitForSeconds(1f);
        _uimanager = FindObjectOfType<UiManager>();
        _uiPanels = FindObjectOfType<UiManager>();
        highscore_savedata = FindObjectOfType<SaveData>();
        _generateGlass = FindObjectOfType<GenerateGlass>();
        uiAnimation = FindObjectOfType<UiManager>();
        secondTime = 60;

    }

    private void Start()
    {
        StartCoroutine(Ienum_decreasetime());
    }


    IEnumerator Ienum_decreasetime() 
    {
        bool playloop = true;
        bool isAlert = false;
        while (playloop) 
        {
            yield return oneSecond;
            if (secondTime <= 10f && isAlert==false) 
            {
                isAlert = true;
                //play animation
                uiAnimation.txtTimerAnimation.SetBool("isAlert", isAlert);
                AudioManager.Instance.getbackgroundgameplaysound().volume = .5f;
                AudioManager.Instance.getSoundnearendtime().Play();
            
            
            }


            if (secondTime <= 0f) 
            {
                playloop = false;
                //showPanel End game
                highscore_savedata.SetHighscore();
                _generateGlass.disableParentArenaGlasses();
                _uiPanels.ShowPanelEndGame();
                
                Debug.Log("finish game");
            
            }
            secondTime -= 1;
            _uimanager.PrintTime(secondTime);
        
        }
    
    
    
    
    
    }


}
