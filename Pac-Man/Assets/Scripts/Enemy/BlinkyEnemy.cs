using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlinkyEnemy : MonoBehaviour
{
    [SerializeField]
    Transform destination;

    NavMeshAgent navMeshA;

    public Camera cam;
    public GameManager GM;
    public UIManager UI;
    public GameObject EnemyBlinky, EnemyClyde, EnemyInky, EnemyPinky;

    void Start()
    {
        GM = GameManager.FindObjectOfType<GameManager>();
        UI = UIManager.FindObjectOfType<UIManager>();
        cam = FindObjectOfType<Camera>();

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
    }
}
