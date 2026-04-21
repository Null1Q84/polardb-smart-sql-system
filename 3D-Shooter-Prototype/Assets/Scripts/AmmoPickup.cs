using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [Header("弹药设置")]
    public int ammoAmount = 30;
    public float respawnTime = 10f;
    
    private bool isActive = true;
    
    void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;
        
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            // 这里可以添加弹药恢复逻辑
            Debug.Log("弹药拾取 +" + ammoAmount);
            
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