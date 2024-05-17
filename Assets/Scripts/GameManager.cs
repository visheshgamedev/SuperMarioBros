using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int world { get; private set; }
    public int area { get; private set; }
    public int lives { get; private set; }
    public int score { get; private set; }
    public int coins { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        lives = 3;
        coins = 0;
        score = 0;

        LoadLevel(1, 1);
    }

    public void ResetLevel()
    {
        lives--;

        if (lives > 0)
        {
            LoadLevel(world, area);
        }
        else
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    private void LoadLevel(int world, int area)
    {
        this.world = world;
        this.area = area;

        SceneManager.LoadScene($"World {world}-{area}");
    }
    
    public void AddCoin()
    {
        coins++;

        if (coins == 100)
        {
            coins = 0;
            AddLife();
        }
    }

    public void AddLife()
    {
        lives++;
    }

    public void AddScore(int AddScore)
    {
        score += AddScore;
    }
}