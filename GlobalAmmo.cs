using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
    public static int CurrentAmmo = 0;
    public static int LoadedAmmo = 10;

    public Text AmmoDisplay;
    public Text LoadedDisplay;

    void Update()
    {
        AmmoDisplay.text = CurrentAmmo.ToString();
        LoadedDisplay.text = LoadedAmmo.ToString();
    }
}
