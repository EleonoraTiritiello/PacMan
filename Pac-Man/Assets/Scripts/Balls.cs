using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public Player ActualPlayer;
    public GameObject PacMan;
    public UIManager UI;
    public GameManager GM;
    public Player PM;
    public GameObject ballsPrefab;
    GameObject[] ball;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        UI = UIManager.FindObjectOfType<UIManager>();
        PM = Player.FindObjectOfType<Player>();

        ball = new GameObject[20];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (this.gameObject)
            {
                GM.ActualScore += 50;
                UI.UpdateScore();
                Destroy(this.gameObject);
            }
            else
            {
               
            }
        }

    }
    public void SpawnBalls()
    {
        for (int i = 0; i < 20; i++)
        {
            ball[i] = GameObject.Instantiate(ballsPrefab);
            ball[i].gameObject.transform.position = new Vector3(Random.Range(-10, 10), 0.0f, Random.Range(-10, 10));

        }
    }

    void ResetBalls()
    {

    }
}
