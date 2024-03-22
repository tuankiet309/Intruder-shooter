using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_OG : MonoBehaviour
{
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume;
    [SerializeField] AudioClip damagedClip;
    [SerializeField][Range(0f,1f)] float damagedVolume;

    public virtual AudioClip GetShootingAudio()
    {
        return shootingClip;
    }
    public virtual float GetShootingVolume()
    {
        return shootingVolume;
    }
    public virtual AudioClip GetDamagedAudio()
    {
        return damagedClip; 
    }
    public virtual float GetDamagedVolume() 
    {
        return damagedVolume;
    }
}
