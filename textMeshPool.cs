using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textMeshPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> txtmeshBlue;
    [SerializeField] private List<GameObject> txtmeshyello;
    [SerializeField] private List<GameObject> txtmeshred;



    public GameObject objpoolBlue() 
    {
        byte index = 0;
        for (byte i = 0; i < txtmeshBlue.Count; i++)
        {
            if (!txtmeshBlue[i].activeInHierarchy) 
            {
                index = i;
                return txtmeshBlue[i];
            }
        }

        return txtmeshBlue[index];
    
    
    }


    public GameObject objpoolyellow()
    {
        byte index = 0;
        for (byte i = 0; i < txtmeshyello.Count; i++)
        {
            if (!txtmeshyello[i].activeInHierarchy)
            {
                index = i;
                return txtmeshyello[i];
            }
        }

        return txtmeshyello[index];


    }

    public GameObject objpoolRed()
    {
        byte index = 0;
        for (byte i = 0; i < txtmeshred.Count; i++)
        {
            if (!txtmeshred[i].activeInHierarchy)
            {
                index = i;
                return txtmeshred[i];
            }
        }

        return txtmeshyello[index];


    }



}
