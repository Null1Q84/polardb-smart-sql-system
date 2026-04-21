using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("菜单按钮")]
    public Button startButton;
    public Button optionsButton;
    public Button quitButton;
    
    void Start()
    {
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);
        
        if (optionsButton != null)
            optionsButton.onClick.AddListener(OpenOptions);
        
        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
    }
    
    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    void OpenOptions()
    {
        // 打开设置菜单
        Debug.Log("打开设置菜单");
    }
    
    void QuitGame()
    {
        Application.Quit();
        Debug.Log("退出游戏");
    }
}