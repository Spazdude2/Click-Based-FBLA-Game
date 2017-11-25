using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public NavMeshAgent PlayerAgent;

    public virtual void MoveToInteraction(NavMeshAgent PlayerAgent)
    {
        this.PlayerAgent = PlayerAgent;
        PlayerAgent.stoppingDistance = 20f;
        PlayerAgent.destination = this.transform.position;

        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
