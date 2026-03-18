using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioClip AmmoClip; // drag the sound file here instead

    void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(AmmoClip, transform.position);

        if (GlobalAmmo.LoadedAmmo == 0)
        {
            GlobalAmmo.LoadedAmmo += 10;
        }
        else
        {
            GlobalAmmo.CurrentAmmo += 10;
        }

        this.gameObject.SetActive(false);
    }
}

