using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassScaleManager : MonoBehaviour
{
   public Vector3 _orginalScale;
    public Vector3 _newScale;
    [SerializeField] private float _time;


    private void Awake()
    {
        _orginalScale = new Vector3(1f,1f,1f);
    }


    public void backToOrginalScale(GameObject objglass) 
    {
        objglass.transform.localScale = _orginalScale;
    
    }

   public IEnumerator Ienum_ChangeScale(GameObject objglass,Vector3 orginalScale,Vector3 newScale) 
    {
        float result = 0;
        float currenttime = 0;
        while (result != 1) 
        {
           
            yield return new WaitForSeconds(Time.deltaTime);
            currenttime += 1f;
            result =currenttime / _time;
            objglass.transform.localScale = Vector3.Slerp(orginalScale, newScale, result);
        
                
        }
    
    
    
    } 





}
