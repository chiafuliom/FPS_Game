using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGunDamage : MonoBehaviour {

    public int DamageAmount = 5; //health to deduct on hit
    public float TargetDistance;
    public float AllowedRange = 15.0f;  //how far away we can be from the target


  void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                RaycastHit Shot;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))//if anything is in front of my Raycast
                {
                    TargetDistance = Shot.distance; //whatever is hit by the raycast, it's distance gets stored in TargetDistance
                    if (TargetDistance < AllowedRange) //if the distance between me and the raycast hit is less than the AllowedRange...
                    {
                        Shot.transform.SendMessage("DeductPoints", DamageAmount, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
    }


    //=====

  
}
