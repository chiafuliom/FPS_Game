using UnityEngine;

public class Gunshot: MonoBehaviour
{
    Animator anim;
    AudioSource audioSource;

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (GlobalAmmo.LoadedAmmo >= 1 && Input.GetButtonDown("Fire1"))
        {
            audioSource.Play();
            anim.SetTrigger("Fire");
            GlobalAmmo.LoadedAmmo--;
        }
    }
}

