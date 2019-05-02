using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunReload : MonoBehaviour {

    public AudioSource ReloadSound;  //loads sound FX
    public GameObject CrossObject;  //allows us to turn off the crosshairs on reload
    public GameObject MechanicsObject;
    public int ClipCount;
    public int ReserveCount;
    public int ReloadAvailable;
   // public GunShot GunComponent;

    void Start()
    {
     //   GunComponent = GetComponent<GunShot>();
    }

    void Update()
    {
        ClipCount = GlobalAmmo.LoadedAmmo; //These are the bullets in the gun
        ReserveCount = GlobalAmmo.CurrentAmmo;  //These are the extra bullets from the ammo pickups

        if (ReserveCount == 0) //if I have no bullets leftover from the ammo pickups
        {
            ReloadAvailable = 0;  //no ability to reload
        }
        else
        {
            ReloadAvailable = 10 - ClipCount; //since our gun only holds 10 shells, we can only load from our reserve minus what's left in the gun
        }

         if (Input.GetButtonDown("Reload")) //if the user presses the reload key
        {
            if (ReloadAvailable >= 1) //and if we actually have available bullets in reserve...
            {
                if (ReserveCount <= ReloadAvailable) // and if the available bullets are less than or equal to the available chambers in the gun
                {
                    GlobalAmmo.LoadedAmmo += ReserveCount; // add to the gun all available bullets from reserve
                    GlobalAmmo.CurrentAmmo -= ReserveCount; //take away that same number away from the reserve
                    ActionReload(); // play the animation and sound and disable firing for a quick sec
                }
                else
                {
                    GlobalAmmo.LoadedAmmo += ReloadAvailable; //add to the gun the value of ReloadAvailable
                    GlobalAmmo.CurrentAmmo -= ReloadAvailable;//take away that same number away from reserve
                    ActionReload(); // play the animation and sound and disable firing for a quick sec
                }
            }
            StartCoroutine(EnableScripts());

        }
    }

    IEnumerator EnableScripts()
    {
        yield return new WaitForSeconds(1.1f);  //pause for 1.1 seconds to wait for the reload animation to play
      //  GunShot.enabled = true; //re-enable the GunShot script
        CrossObject.SetActive(true); //re-enable the crosshairs
        MechanicsObject.SetActive(true); //re-enable the gun mechanics
    }

    void ActionReload()
    {
      //  GunShot.enabled = false; //don't allow firing
        CrossObject.SetActive(false); //don't display the crosshairs
        MechanicsObject.SetActive(false); //turn off gun mechanics
        ReloadSound.Play(); //play the sound FX
        GetComponent<Animation>().Play("HandgunReload"); //play the animation of reloading
    }
}
