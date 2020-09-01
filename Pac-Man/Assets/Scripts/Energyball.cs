using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energyball : MonoBehaviour
{
    public GameObject energyBalls;
    public Player Pacman;
    public GameManager GM;
    public UIManager UI;

    // Start is called before the first frame update
    void Start()
    {
        Pacman = Player.FindObjectOfType<Player>();
        GM = GameManager.FindObjectOfType<GameManager>();
        UI = UIManager.FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (this.gameObject)
            {
                Destroy();
                GM.ActualScore += 200;
                UI.UpdateScore();
                Destroy(this.gameObject);
            }
            else
            {
               // this.gameObject.transform.localScale;
            }
        }

    }
    
}

