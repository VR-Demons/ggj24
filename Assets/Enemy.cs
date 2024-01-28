using HurricaneVR.Framework.Core.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindFirstObjectByType<HVRPlayerController>().transform;
    }
    private void Update()
    {
        agent.destination= player.position-(player.position-transform.position).normalized;
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);
    }
}
