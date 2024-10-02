using UnityEngine.UI;
using UnityEngine;
using System;

public class UiManager : MonoBehaviour,IUiPrints,IUiPanels,IUiAnimation,IUiSlider,IDisposable
{
    #region variable
    IHighScoremethodes higschore_savedata;


    public Text txtTimer, txtScore;

    [SerializeField] private Text txtCurrentScore, txtHighScore,txtMonsterHealth,txtPlayerHealth;
    [SerializeField] private GameObject PanelEndGame;
    [SerializeField] private GameObject PanelHud;
    [SerializeField] private Slider MonsterAttackSlider;
    private bool _dispose=false;

    public Animator txtTimerAnimation => txtTimer.gameObject.GetComponent<Animator>();

    public Slider SliderTimeAttack { get { return MonsterAttackSlider; } set { } }
    #endregion

    void Awake() 
    {
        higschore_savedata = FindObjectOfType<SaveData>();   
    }


    #region methodes Iuiprints
    public void PrintScore(short score)
    {
       
        txtScore.text = "Score:" + score;
    }

    public void PrintTime(short timenumber)
    {
        txtTimer.text = timenumber.ToString();
    }

    public void appearDatainEndGamePanel()
    {
        txtCurrentScore.text = "Current Score:" + higschore_savedata.GetCurrentScore();
        txtHighScore.text = higschore_savedata.GetHighscore().ToString();
    }

    public Text printMonsterHealth()
    {
        return txtMonsterHealth;
    }

    public Text PrintPlayerHealth()
    {
      
        return txtPlayerHealth;
    }

    #endregion


    #region method interface Ipanel
    public void ShowPanelEndGame()
    {
        PanelEndGame.SetActive(true);
        appearDatainEndGamePanel();
        PanelHud.SetActive(false);
    }
    #endregion
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool Dispose) 
    {
        if (_dispose == false) 
        {
            if (Dispose) 
            {
              
            
            }
        
        
        
        
        }
        _dispose = true;
    
    
    }













}
