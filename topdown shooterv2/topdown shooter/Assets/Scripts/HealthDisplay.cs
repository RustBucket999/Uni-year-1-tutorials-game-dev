using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public Health playerHealth;
    public TMP_Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + playerHealth.currentHealth + "/" + playerHealth.maxHealth;
    }
}
