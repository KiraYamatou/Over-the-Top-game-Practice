using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{
    public AudioClip deathClipCow, deathClipDog, deathClipStag, deathClipPlayer, damageClipPlayer;

    public void deathSoundCow()
    {
        AudioSource.PlayClipAtPoint(deathClipCow, transform.position);
        Debug.Log("Cow sound played from DeathSound Class");
    }
    public void deathSoundDog()
    {
        AudioSource.PlayClipAtPoint(deathClipDog, transform.position);
    }
    public void deathSoundStag()
    {
        AudioSource.PlayClipAtPoint(deathClipStag, transform.position);
    }
    public void deathSoundPlayer()
    {
        AudioSource.PlayClipAtPoint(deathClipPlayer, transform.position);
    }
    public void damageSoundPlayer()
    {
        AudioSource.PlayClipAtPoint(damageClipPlayer, transform.position);
    }
}
