using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private LerpSlides _lerpclass;

    [SerializeField] private Vector3 CameraOrginalPosition;
    [SerializeField] private float TimeShake;
    [SerializeField] private float MagnetShake;
    [SerializeField] private float ferquently;
    [SerializeField] private float Speed;

    private Vector3 cameraCurrentPostion;
    private Camera cameraobj;
    private float LastTimeShake;


    private void Awake()
    {
        cameraobj = Camera.main;
        CameraOrginalPosition =cameraobj.transform.localPosition;
        _lerpclass = FindObjectOfType<LerpSlides>();
       
    }


    public void startCoroutine() 
    {
        StartCoroutine(IenumShake());
    
    }

    IEnumerator IenumShake() 
    {
        float CurrentTime = TimeShake;
        bool whiltro = true;
        while (CurrentTime>0f && whiltro) 
        {
            yield return null;
            LastTimeShake += Time.deltaTime;
            if (LastTimeShake >= 1f / ferquently) 
            {
                LastTimeShake = 0;
               Vector3  randomshake = Random.insideUnitSphere * MagnetShake;
                cameraobj.transform.localPosition = Vector3.Lerp(cameraobj.transform.localPosition, CameraOrginalPosition + randomshake, Time.deltaTime * Speed);



            }
            
            CurrentTime -= Time.deltaTime;

            if (CurrentTime <= 0f)
                whiltro = false;
        
        
        
        
        }
      
        cameraobj.transform.localPosition = CameraOrginalPosition;
        StartCoroutine(_lerpclass.Ienum_backtoOne());
        //again settime back to full slider 
        
    
    
    
    }












}
