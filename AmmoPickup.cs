using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public AudioSource AmmoSound; //sound effect of picking up the ammo crate
    void OnTriggerEnter(Collider other) //when this triggered box collider makes contact with the player...
    {
        AmmoSound.Play();//play the sound FX of picking up the crate

        if (GlobalAmmo.LoadedAmmo == 0)//if the bullets in the first display reach zero...
        {
            GlobalAmmo.LoadedAmmo += 10;//add ten to the first display
            this.gameObject.SetActive(false);//make the crate disappear
        }
        else
        {
            GlobalAmmo.CurrentAmmo += 10;//otherwise add 10 to the reserve ammo in the second display
            this.gameObject.SetActive(false);//make the crate disappear
        }
    }
}

