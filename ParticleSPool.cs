using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSPool : MonoBehaviour, IpoolObjects
{

    [SerializeField] private List<GameObject> listParticlesBlue;
    [SerializeField] private List<GameObject> listParticlesYellow;
    [SerializeField] private List<GameObject> ListParticlesRed;





    public GameObject getObjectFrompoolBlue()
    {
        for (int i = 0; i < listParticlesBlue.Count; i++)
        {
            if (!listParticlesBlue[i].activeInHierarchy) 
            {
                return listParticlesBlue[i];
                
            
            }
        }

        return null;
    }

    public GameObject getObjectFrompoolRed()
    {
        for (int i = 0; i < ListParticlesRed.Count; i++)
        {
            if (!ListParticlesRed[i].activeInHierarchy)
            {
                return ListParticlesRed[i];


            }
        }

        return null;
    }

    public GameObject getObjectFrompoolYellow()
    {
        for (int i = 0; i < listParticlesYellow.Count; i++)
        {
            if (!listParticlesYellow[i].activeInHierarchy)
            {
                return listParticlesYellow[i];


            }
        }

        return null;
    }
}
