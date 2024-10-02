using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTouch : MonoBehaviour
{
    private LagicScore _lagicscore;
    private GlassScaleManager _glassScaleManager;
   
    public bool isSelect;
    private void Awake()
    {
        _lagicscore = FindObjectOfType<LagicScore>();
        _glassScaleManager = FindObjectOfType<GlassScaleManager>();
       
    }


    private void OnMouseDown()
    {
        if (isSelect == false)
        {
            isSelect = true;
            StartCoroutine(_glassScaleManager.Ienum_ChangeScale(this.gameObject,_glassScaleManager._orginalScale,_glassScaleManager._newScale));
            _lagicscore.NewGlassName = this.gameObject.name;

            _lagicscore.Glasses.Add(this.gameObject);
            //_lagicscore.GlassesForDelete.Add(this.gameObject);
            _lagicscore.Check3Match();

        }
        else 
        {
            isSelect = false;
            backToOrginalScale_solo();
            _lagicscore.Glasses.Remove(this.gameObject);
            _lagicscore.ClearData();
            
        }
    }



    public void backToOrginalScale_solo() 
    {
        int indexlist = _lagicscore.Glasses.IndexOf(this.gameObject);

        StartCoroutine(_lagicscore.Glasses[indexlist]
           .GetComponent<GlassScaleManager>()
            .Ienum_ChangeScale(_lagicscore.Glasses[indexlist], _glassScaleManager._newScale, _glassScaleManager._orginalScale)); ;
        
    
    
    }







}
