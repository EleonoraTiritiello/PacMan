using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;
    public Camera cam;
    public int Life;
    public GameManager GM;
    public bool ReciveDamage;
    public float time;
    public Rigidbody RB;
    //private Vector3 directionToMove;

    // Start is called before the first frame update
    void Start()
    {
        ReciveDamage = true;
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CrossScreen();

        if (ReciveDamage == false)
        {
            RecordTime();
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        } 
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        } 
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        } 
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        } 
          
    }

    

    void CrossScreen()
    {

        Vector3 screenPoint = cam.WorldToViewportPoint(transform.position);

        //if out of the screen, teleport to the other side

        if (screenPoint.x > 1)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(0, screenPoint.y, screenPoint.z));
        }
        else if (screenPoint.x < 0)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(1, screenPoint.y, screenPoint.z));
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<EnemyManager>())
        {
            if (CheckTime(2.0f) && !ReciveDamage)
            {
                ReciveDamage = true;
                ResetTime();
            }
            if (ReciveDamage)
            {
                if (Life <= 1)
                {
                    Life -= 1;
                    GM.UI.SetCurrentPlayerLife();
                    GM.UI.ActiveUI();
                    Destroy(this.gameObject);

                }
                else
                {
                    Life -= 1;
                    ReciveDamage = false;
                    transform.position = new Vector3(0, -4f, -7.5f);
                    GM.UI.SetCurrentPlayerLife();
                    GM.UI.ActiveUI();
                }
            }

        }
    }

    private void RecordTime()
    {
        time += Time.deltaTime;
    }

    private void ResetTime()
    {
        time = 0.0f;
    }

    private bool CheckTime(float valueToCheck)
    {
        if (time >= valueToCheck)
            return true;
        else return false;
    }
}
