using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _backgroundGameplaymusic;
    [SerializeField] private AudioSource _soundNearEndTime;

    public void Awake()
    {
        Instance = this;
       
    }




    public AudioSource getbackgroundgameplaysound() 
    {
        return _backgroundGameplaymusic;
    
    }

    public AudioSource getSoundnearendtime()
    {
        return _soundNearEndTime;

    }







}
