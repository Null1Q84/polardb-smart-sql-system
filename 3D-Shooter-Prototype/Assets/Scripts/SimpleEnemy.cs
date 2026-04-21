using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    [Header("敌人属性")]
    public float speed = 2f;
    public float attackRange = 2f;
    public float attackDamage = 10f;
    public float health = 50f;
    
    private Transform player;
    private bool isAttacking = false;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    void Update()
    {
        if (player == null) return;
        
        float distance = Vector3.Distance(transform.position, player.position);
        
        if (distance <= attackRange)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }
    
    void Move()
    {
        Vector3 direction = player.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
    
    void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Invoke("PerformAttack", 0.5f);
        }
    }
    
    void PerformAttack()
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        isAttacking = false;
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
        {
            gm.AddScore(100);
        }
        
        Destroy(gameObject);
    }
}