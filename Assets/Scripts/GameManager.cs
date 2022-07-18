using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int coins;

    private void Awake()
    {
        //if there is an instance and it is not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            coins = 0;
        }
    }

    public int GetCoins()
    {
        return coins;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
