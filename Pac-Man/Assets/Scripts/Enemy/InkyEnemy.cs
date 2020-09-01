using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InkyEnemy : MonoBehaviour
{
    [SerializeField]
    Transform destination;

    NavMeshAgent navMeshA;

    public Camera cam;
    public GameManager GM;
    public UIManager UI;
    public GameObject EnemyBlinky, EnemyClyde, EnemyInky, EnemyPinky;
    public EnemyManager EM;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        UI = UIManager.FindObjectOfType<UIManager>();
        cam = Camera.FindObjectOfType<Camera>();
        EM = EnemyManager.FindObjectOfType<EnemyManager>();

        navMeshA = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (destination != null)
        {
            Vector3 targetVector = destination.transform.position;
            navMeshA.SetDestination(targetVector);
        }

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
        else if (screenPoint.y > 1)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(screenPoint.x, 0, screenPoint.z));
        }
        else if (screenPoint.y < 0)
        {
            transform.position = cam.ViewportToWorldPoint(new Vector3(screenPoint.x, 1, screenPoint.z));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Energyball>())
        {
            if (this.gameObject.transform.localScale.magnitude <= new Vector3(-2.82f, -4f, -2.5f).magnitude)
            {
                GM.ActualScore += 100;
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
