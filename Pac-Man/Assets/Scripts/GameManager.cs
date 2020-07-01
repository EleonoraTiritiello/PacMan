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
            Object.FindObjectOfType<Player>().gameObject.transform.position = new Vector3(0, -19f, 0);
            ActualScore = 0;
            EndMenu();
        }
    }

    public void LoseCondition()
    {
 
         EndMenu();
        
    }
}
