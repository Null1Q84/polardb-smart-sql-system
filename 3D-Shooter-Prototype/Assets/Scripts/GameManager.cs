using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI设置")]
    public Text scoreText;
    public Text healthText;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    
    [Header("游戏设置")]
    public int enemyCount = 10;
    public GameObject enemyPrefab;
    public Transform spawnArea;
    
    private int score = 0;
    private int remainingEnemies;
    
    void Start()
    {
        remainingEnemies = enemyCount;
        SpawnEnemies();
        UpdateUI();
    }
    
    void SpawnEnemies()
    {
        if (enemyPrefab == null || spawnArea == null) return;
        
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPosition = spawnArea.position + new Vector3(
                Random.Range(-10f, 10f),
                0,
                Random.Range(-10f, 10f)
            );
            
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
    
    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
        
        remainingEnemies--;
        if (remainingEnemies <= 0)
        {
            WinGame();
        }
    }
    
    void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
        
        if (healthText != null)
            healthText.text = "Enemies: " + remainingEnemies;
    }
    
    void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
    
    void WinGame()
    {
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }
    
    void Update()
    {
        // 检查玩家是否死亡
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            GameOver();
        }
    }
}