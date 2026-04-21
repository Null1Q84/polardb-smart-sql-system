using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("武器设置")]
    public GameObject[] weapons;
    public int currentWeaponIndex = 0;
    
    [Header("武器属性")]
    public float[] fireRates = {0.5f, 0.2f, 1f};
    public float[] bulletSpeeds = {20f, 30f, 15f};
    public float[] bulletDamages = {10f, 15f, 5f};
    
    void Start()
    {
        SwitchWeapon(currentWeaponIndex);
    }
    
    void Update()
    {
        // 切换武器
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(2);
        }
    }
    
    void SwitchWeapon(int index)
    {
        if (index >= weapons.Length) return;
        
        // 隐藏所有武器
        foreach (GameObject weapon in weapons)
        {
            if (weapon != null)
                weapon.SetActive(false);
        }
        
        // 显示当前武器
        weapons[index].SetActive(true);
        currentWeaponIndex = index;
        
        // 更新射击参数
        PlayerController player = GetComponent<PlayerController>();
        if (player != null)
        {
            player.fireRate = fireRates[index];
            player.bulletSpeed = bulletSpeeds[index];
            player.bulletDamage = bulletDamages[index];
        }
    }
}