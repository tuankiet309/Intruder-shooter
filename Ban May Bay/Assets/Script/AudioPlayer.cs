using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
   
    public void PlayClip(AudioClip clip,float volume)
    {
        if(clip != null) 
        {
             AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,volume);
        }
    }
}
