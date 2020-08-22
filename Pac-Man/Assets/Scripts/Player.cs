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
    public Rigidbody rB;
    private Vector3 directionToMove;
    public float rotationSpeed = 100.0f;

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

        rB = GetComponent<Rigidbody>();


      // float translation = Input.GetAxis("Vertical") * speed;
      //
      // translation *= Time.deltaTime;
      //
      // transform.Translate(0, 0, translation);
      //
      // float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
      //
      // rotation *= Time.deltaTime;
      //
      // transform.Rotate(0, rotation, 0);

    }

    void Movement()
    {
        if(Input.GetAxis("Horizontal") < 0)
        {
            directionToMove = Vector3.left;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {      
            directionToMove = Vector3.right;
        }

        if (Input.GetAxis("Vertical") < 0)
        {           
            directionToMove = Vector3.back;
        }

        if (Input.GetAxis("Vertical") > 0)
        {       
            directionToMove = Vector3.forward;
        }

        rB.velocity = directionToMove * speed;
        transform.up = directionToMove;

       /* if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        } 
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        } 
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        } 
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        } */
          
          //  transform.Translate(Vector3.up * speed * Time.deltaTime);
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
