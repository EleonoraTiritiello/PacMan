using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region VARIABLES
    public int ActualScore;
    public int ScoreToWin;
    public Player ActualPlayer;
    public GameObject PacMan;
    public UIManager UI;
    public GameObject ballsPrefab;
    GameObject[] balls;
    #endregion

    public void Awake()
    {
        ActualPlayer = FindObjectOfType<Player>();
        balls = new GameObject[20];
    }

    private void Update()
    {
        VictoryCondition();
        LoseCondition();
    }


    public void GoToGameplay()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToEndMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void EndMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void VictoryCondition()
    {
        if (ActualScore >= ScoreToWin)
        {
            for (int i = 0; i < Object.FindObjectsOfType<Balls>().Length; i++)
            {
                Destroy(Object.FindObjectsOfType<Balls>()[i].gameObject);
            }

            Object.FindObjectOfType<Player>().gameObject.transform.position = new Vector3(0, -4f, -7.5f);
            ActualScore = 0;

            EndMenu();
        }
    }

    public void LoseCondition()
    {

         if (ActualPlayer.Life <= 0)
         {

             for (int i = 0; i < Object.FindObjectsOfType<EnemyManager>().Length; i++)
             {
                 Destroy(Object.FindObjectsOfType<EnemyManager>()[i].gameObject);
             }

             EndMenu();
         }
      

    }

    public void SpawnBalls()
    {
       for (int i = 0; i < 20; i++)
       {
           balls[i] = GameObject.Instantiate(ballsPrefab);
           balls[i].gameObject.transform.position = new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10));

       }
    }

}
