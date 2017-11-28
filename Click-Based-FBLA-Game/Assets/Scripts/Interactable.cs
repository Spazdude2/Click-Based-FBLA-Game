using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    private bool hasInteracted;

    public NavMeshAgent PlayerAgent;

    public virtual void MoveToInteraction(NavMeshAgent PlayerAgent)
    {
        hasInteracted = false;
        this.PlayerAgent = PlayerAgent;
        PlayerAgent.stoppingDistance = 20f;
        PlayerAgent.destination = this.transform.position;
    }

    void Update()
    {
        if (!hasInteracted && PlayerAgent != null && !PlayerAgent.pathPending)
        {
            if (PlayerAgent.remainingDistance <= PlayerAgent.stoppingDistance)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
