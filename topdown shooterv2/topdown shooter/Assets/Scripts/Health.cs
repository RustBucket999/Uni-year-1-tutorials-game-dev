using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float flashDuration = 0.1f;
    public Color damageColor = Color.red;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer != null )
        {
            originalColor = spriteRenderer.color;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (spriteRenderer != null)
        {
            StartCoroutine(FlashRed());
        }

        if (currentHealth <= 0)
        {
            Die();
        }  
        
    }
    
    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);
    }

    private void Die()
    {
        Debug.Log("Player died!");
    }

    private IEnumerator FlashRed()
    {
        int flashCount = 2;
        float flashDuration = 0.5f;
        float flashInterval = flashDuration / flashCount;

        for (int i = 0; i < flashCount; i++)
        {
            //flash to red
            spriteRenderer.color = damageColor;
            //wait for half of the flash interval
            yield return new WaitForSeconds(flashInterval / 2);
            //flash to original colour
            spriteRenderer.color = originalColor;
            //wait for the other half of the flash interval
            yield return new WaitForSeconds(flashInterval / 2);
        }    
    }
}
