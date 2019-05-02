using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour {

    public GameObject flash;
    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (GlobalAmmo.LoadedAmmo >=1) {
            if (Input.GetButtonDown("Fire1"))
            {
                flash.SetActive(true);
                StartCoroutine(MuzzleOff());
                AudioSource gunsound = GetComponent<AudioSource>();
                gunsound.Play();
                GetComponent<Animation>().Play("NewGun");
                GlobalAmmo.LoadedAmmo -= 1;
                
            }
        }
    }
    IEnumerator MuzzleOff()
    {
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }
    }

