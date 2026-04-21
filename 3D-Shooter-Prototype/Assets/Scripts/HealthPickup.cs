using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [Header("血量恢复设置")]
    public float healAmount = 25f;
    public float respawnTime = 20f;
    
    private bool isActive = true;
    
    void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;
        
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.currentHealth += healAmount;
            
            if (playerHealth.currentHealth > playerHealth.maxHealth)
                playerHealth.currentHealth = playerHealth.maxHealth;
            
            playerHealth.UpdateHealthUI();
            
            Debug.Log("血量恢复 +" + healAmount);
            
            isActive = false;
            gameObject.SetActive(false);
            
            Invoke("Respawn", respawnTime);
        }
    }
    
    void Respawn()
    {
        isActive = true;
        gameObject.SetActive(true);
    }
}