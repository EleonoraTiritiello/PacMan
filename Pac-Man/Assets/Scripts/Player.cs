using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditorInternal;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region VARIABLES
    public int speed;
    public Camera cam;
    public int Life;
    public GameManager GM;
    public bool ReciveDamage;
    public float time;
    public Rigidbody rB;
    private Vector3 directionToMove;
    private AudioSource source;
    public bool loop;
    EnemyManager EM;
    Energyball EB;
    public UIManager UI;
    Renderer rend;
    public Material[] material;
    [HideInInspector]
    public float currentTime;
    public float timeMax;
    public bool active;
    public bool timeStopped;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ReciveDamage = true;
        cam = Camera.FindObjectOfType<Camera>();
        EM = EnemyManager.FindObjectOfType<EnemyManager>();
        EB = Energyball.FindObjectOfType<Energyball>();
        UI = UIManager.FindObjectOfType<UIManager>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        timeStopped = false;

    }
    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.loop = this.loop;
    }
    public void PlayAudio()
    {
        source.Play();
    }
    public void StopAudio()
    {
        source.Stop();
    }

    public void SetLoop(bool loop)
    {
        source.loop = loop;
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
        else if (screenPoint.y > 1)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(screenPoint.x, 0, screenPoint.z));
        }
        else if (screenPoint.y < 0)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(screenPoint.x, 1, screenPoint.z));
        }
    }

    void Die()
    {
       // AudioSource.PlayClipAtPoint.PlayAudio;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<InkyEnemy>())
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

            if (collision.gameObject.tag == "PacMan")
            {
                rend.sharedMaterial = material[0];

                GM.ActualScore += 20;
                UI.UpdateScore();
                Destroy(this.gameObject);
            }
            else
            {
                Timer();
                rend.sharedMaterial = material[0];
            }


        }
    }


    void Timer()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        else
        {
            currentTime = 0;
            active = false;
        }
    }


    public void Destroy()
    {
        Destroy(gameObject);
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
