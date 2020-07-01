using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public string TextScore = "Score";
    public Text Score;
    public Transform LifeToSpawn;
    GameManager GameManager;
    public GameObject lifePrefab1, lifePrefab2, lifePrefab3;
    int playerLife;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
        Score.text = TextScore + GameManager.ActualScore;
    }

    public void Start()
    {
        SetCurrentPlayerLife();
    }

    public void ActiveUI()
    {
        if (playerLife == 3)
        {
            lifePrefab1.SetActive(true);
            lifePrefab2.SetActive(true);
            lifePrefab3.SetActive(true);
        }
        if (playerLife == 2)
        {
            lifePrefab1.SetActive(true);
            lifePrefab2.SetActive(true);
            lifePrefab3.SetActive(false);
        }
        if (playerLife == 1)
        {
            lifePrefab1.SetActive(true);
            lifePrefab2.SetActive(false);
            lifePrefab3.SetActive(false);
        }
        if (playerLife == 0)
        {
            lifePrefab1.SetActive(false);
            lifePrefab2.SetActive(false);
            lifePrefab3.SetActive(false);
        }
    }

    public void SetCurrentPlayerLife()
    {
        playerLife = GameManager.ActualPlayer.Life;
    }

    public void UpdateScore()
    {
        Score.text = TextScore + GameManager.ActualScore;
    }
}
