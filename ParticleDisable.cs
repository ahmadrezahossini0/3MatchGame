using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDisable : MonoBehaviour
{

    private void OnEnable()
    {
        Invoke("disactive", .5f);
    }


    private void disactive() 
    {
        gameObject.SetActive(false);
    
    }

}
