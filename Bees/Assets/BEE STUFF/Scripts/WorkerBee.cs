using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.AI;

public class WorkerBee : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform spawningSpot;
    public GameObject nectarGO;
    private bool done;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(FindObjectOfType<XROrigin>().transform.position);
    }

    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (!done)
            {
                Instantiate(nectarGO, spawningSpot.position, Quaternion.identity);
                RecallWorkerBee();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

    }


    public void RecallWorkerBee()
    {
        agent.SetDestination(FindObjectOfType<WorkerBeeSpawner>().transform.position);
        done = true;
    }
}
