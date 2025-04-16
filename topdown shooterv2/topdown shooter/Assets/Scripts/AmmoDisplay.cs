using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    public Weapon weapon;
    public TMP_Text ammoText;
    void Update()
    {

        ammoText.text = "Ammo: " + weapon.currentAmmo + "/" + weapon.maxAmmo;
    }
}
