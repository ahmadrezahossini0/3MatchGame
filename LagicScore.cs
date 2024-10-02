using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class LagicScore : MonoBehaviour
{
    GenerateGlass _generateGlass;
    textMeshPool _txtMeshPool;
    GlassScaleManager _objGlassScale;
    Monster _monster;
    ISetScore scoreManager;
    IpoolObjects particlesPool;
    IHighScoremethodes saveDataManager;
    IUiPrints UiManager;

   public List<GameObject> Glasses;
   public List<GameObject> GlassesForDelete;
    [SerializeField] private string priviouseGlassName;
    public string NewGlassName;
    private GameObject objtxtmeshpro;
    private GameObject objparticleglass;

    private void Awake()
    {
        _generateGlass = FindFirstObjectByType<GenerateGlass>();
        scoreManager = FindObjectOfType<ScoreManager>();
        saveDataManager = FindObjectOfType<SaveData>();
        UiManager = FindObjectOfType<UiManager>();
        _txtMeshPool = FindObjectOfType<textMeshPool>();
        particlesPool = FindObjectOfType<ParticleSPool>();
        _monster = FindObjectOfType<Monster>();
    }

    public void Check3Match() 
    {
        if (Glasses.Count >= 3 && NewGlassName.Equals(priviouseGlassName)) 
        {
            //monsterget new name
            _monster.reciveDamage(NewGlassName);
            scoreManager.setScoreNumber(NewGlassName);
            //show text meshpro score center of screen
            Showtxtmeshpro(NewGlassName);
            UiManager.PrintScore(saveDataManager.GetCurrentScore());
            pushtoListDeleteGlass();
            Glasses.Clear();
            disableobject();
            StartCoroutine(Ienum_growGlass());
         

        }
        else 
        {
            //check plyer select right glass 
            //if select wrong we will get all glass them
            CheckNames(NewGlassName);
        
        }    
    }




    private void pushtoListDeleteGlass() 
    {
        for (int i = 0; i < Glasses.Count; i++)
        {
            GlassesForDelete.Add(Glasses[i]);
        }
    
    }





    private void disableobject() 
    {
       

        for (int i = 0; i < GlassesForDelete.Count; i++)
        {
            switch (NewGlassName)
            {
                case "Glass red":
                    objparticleglass = particlesPool.getObjectFrompoolRed();

                    break;

                case "Glass blue":
                    objparticleglass = particlesPool.getObjectFrompoolBlue();

                    break;


                case "Glass yellow":
                    objparticleglass = particlesPool.getObjectFrompoolYellow();

                    break;

                default:
                   
                    break;

            }



            GlassesForDelete[i].GetComponent<GlassTouch>().isSelect = false;
            GlassesForDelete[i].transform.GetChild(0).gameObject.SetActive(false);
            GlassesForDelete[i].SetActive(false);
            //show particle affects
            if (objparticleglass != null)
            {
                objparticleglass.transform.position = GlassesForDelete[i].transform.position;
                objparticleglass.SetActive(true);
                objparticleglass.GetComponent<ParticleSystem>().Play();
            }




        }
    
    
    }





    private void CheckNames(string Newname) 
    {
        
        if (!NewGlassName.Equals(priviouseGlassName)  && !string.IsNullOrEmpty(priviouseGlassName)) 
        {
             //play sond wrong select
            // play animation disselect object
            GlassesbackToOrginalposition_list();
            Glasses.Clear();
            ClearData();
         
           
        }
        else 
        {
          
            priviouseGlassName=Newname;
        
        }
    
    
    }

    private void Showtxtmeshpro(string objectName) 
    {
        switch (objectName) 
        {
            case "Glass blue":
                objtxtmeshpro = _txtMeshPool.objpoolBlue();
                objtxtmeshpro.transform.position = Vector2.zero;
                objtxtmeshpro.SetActive(true);

                break;

            case "Glass yellow":
                objtxtmeshpro = _txtMeshPool.objpoolyellow();
                objtxtmeshpro.transform.position = Vector2.zero;
                objtxtmeshpro.SetActive(true);

                break;

            case "Glass red":
                objtxtmeshpro = _txtMeshPool.objpoolRed();
                objtxtmeshpro.transform.position = Vector2.zero;
                objtxtmeshpro.SetActive(true);

                break;



        }
    
    }
  


    public void ClearData() 
    {
       // Glasses.Clear();
       // GlassesForDelete.Clear();
        NewGlassName = string.Empty;
        priviouseGlassName = string.Empty;
    
    
    }


    private void GlassesbackToOrginalposition_list() 
    {
        for (int i = 0; i < Glasses.Count; i++)
        {
            Glasses[i].GetComponent<GlassTouch>().isSelect = false;
            _objGlassScale = Glasses[i].GetComponent<GlassScaleManager>();
                StartCoroutine(_objGlassScale
                .Ienum_ChangeScale(Glasses[i], 
                _objGlassScale._newScale,
                _objGlassScale._orginalScale));
        }

    }


    private IEnumerator Ienum_growGlass() 
    {
        ClearData();
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(.25f);
            _generateGlass.GenerateObjectGlass(GlassesForDelete[i]);
            

        }
        GlassesForDelete.Clear();

    }

}
