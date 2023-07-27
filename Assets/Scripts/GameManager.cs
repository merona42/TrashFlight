using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private TextMeshProUGUI text;
    private int coin = 0;
    [SerializeField]
    private int upgradeStandard = 30;
    private bool isGameOver = false;
    public bool getIsGameOver()
    {
        return isGameOver;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void addCoin() 
    { 
        coin++;
        text.SetText(coin.ToString());
        if (coin % upgradeStandard == 0)
        {
            Player player = FindObjectOfType<Player>();
            if (player != null)
            {
                player.upgrade();
            }
        }
    }

    public void setGameOver()
    {
        EnemySpawner enemySpawner = FindObjectOfType<EnemySpawner>();
        if (enemySpawner != null)
        {
            isGameOver = true;
            enemySpawner.stopEnemyRoutine();
            Invoke("showGameOverPanel", 1f);
        }
    }

    void showGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
