using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

  // public void GoToEndMenu()
  // {
  //     SceneManager.LoadScene("EndMenu");
  // }
}
