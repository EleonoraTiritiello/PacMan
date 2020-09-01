using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    #region VARIABLES
    [SerializeField]
    Transform destination;

    NavMeshAgent navMeshA;
    public Camera cam;
    public GameManager GM;
    public UIManager UI;
    public GameObject EnemyBlinky, EnemyClyde, EnemyInky, EnemyPinky;
    BlinkyEnemy blinkEnemy;
    ClydeEnemy clydeEnemy;
    PinkyEnemy pinkyEnemy;
    InkyEnemy inkyEnemy;
    #endregion

    private void OnEnable()
    {
        blinkEnemy = FindObjectOfType<BlinkyEnemy>();
        if (blinkEnemy == null)
        {
            Debug.LogError("blinkEnemy is NULL!");
        }

        clydeEnemy = FindObjectOfType<ClydeEnemy>();
        if (clydeEnemy == null)
        {
            Debug.LogError("clydeEnemy is NULL!");
        }

        inkyEnemy = FindObjectOfType<InkyEnemy>();
        if (inkyEnemy == null)
        {
            Debug.LogError("inkyEnemy is NULL!");
        }

        pinkyEnemy = FindObjectOfType<PinkyEnemy>();
        if (pinkyEnemy == null)
        {
            Debug.LogError("pinkyEnemy is NULL!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        UI = UIManager.FindObjectOfType<UIManager>();
        cam = Camera.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        CrossScreen();
    
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
        if (collision.gameObject.GetComponent<Energyball>())
        {
            if (this.gameObject.transform.localScale.magnitude <= new Vector3(-2.82f, -4f, -2.5f).magnitude)
            {
                GM.ActualScore += 20;
                UI.UpdateScore();
                Destroy(this.gameObject);
            }
            else
            {
                this.gameObject.transform.localScale -= new Vector3(-2.82f, -4f, -2.5f);
            }
        }

    }
}
