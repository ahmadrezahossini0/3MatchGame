using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGlass : MonoBehaviour
{
  [SerializeField]private Transform[] rows;
  [SerializeField] private SpriteRenderer[] glassSprites;
  [SerializeField] private GameObject parentArenaGlasses;
    private GameObject obj;//container glass 
    private GameObject objparticleIce;
  

    private void Awake()
    {
        SetObjectInPosition();
    }

    #region private function
    private void SetObjectInPosition() 
    {
        for (int i = 0; i < rows.Length; i++)
        {
            for (int y = 0; y < rows[i].childCount; y++)
            {
                obj = rows[i].GetChild(y).gameObject;
                obj.AddComponent<SpriteRenderer>();
                GenerateObjectGlass(obj);

            }




        }
    
    
    
    
    }


   
    private void PropertySet(GameObject objgalss, int Glassnumberinarray)
    {
       
        if (Glassnumberinarray == 3) 
        {
            objparticleIce = objgalss.transform.GetChild(0).gameObject;
            objparticleIce.transform.localPosition = Vector2.zero;
            objparticleIce.SetActive(true);
        }
        objgalss.GetComponent<SpriteRenderer>().sprite = glassSprites[Glassnumberinarray].sprite;
        objgalss.GetComponent<SpriteRenderer>().color = glassSprites[Glassnumberinarray].color;
        objgalss.name = glassSprites[Glassnumberinarray].gameObject.name;
        objgalss.GetComponent<GlassScaleManager>().backToOrginalScale(objgalss);
        objgalss.SetActive(true);
    }

    #endregion

    #region public function
    public void GenerateObjectGlass(GameObject objgalss)
    {
        float randomglassNumber = Random.value;
       
       
        if (randomglassNumber <= .2f && randomglassNumber > .0f) 
        {
            PropertySet(objgalss, 3);
          

        }
        else if(randomglassNumber <= .4f && randomglassNumber > .2f) 
        {
            PropertySet(objgalss, 1);
           

        }
        else if (randomglassNumber <= .6f && randomglassNumber > .4f) 
        {
            PropertySet(objgalss, 2);
           

        }
        else if (randomglassNumber <= 1f && randomglassNumber>.6f)
        {
            PropertySet(objgalss, 0);
           

        }





    }

    public void disableParentArenaGlasses()
    {
        parentArenaGlasses.SetActive(false);
    }


    #endregion


}
