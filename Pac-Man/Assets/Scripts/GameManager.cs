using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int ActualScore;
    public int ScoreToWin;
    public Player ActualPlayer;
    public GameObject PacMan;
    public UIManager UI;
    public GameObject pallinaPrefab;

    void Start()
    {
      
        Instantiate(pallinaPrefab, new Vector3(-4f, -4f, -18.73f), Quaternion.identity);
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
        SceneManager.LoadScene(0);
    }


    public void VictoryCondition()
    {
        if (ActualScore >= ScoreToWin)
        {
            Object.FindObjectOfType<Player>().gameObject.transform.position = new Vector3(0, -4f, -7.5f);
            ActualScore = 0;
            EndMenu();
        }
    }

    public void LoseCondition()
    {
 
        // EndMenu();
        
    }
}
