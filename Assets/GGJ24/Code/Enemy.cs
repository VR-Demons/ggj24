using HurricaneVR.Framework.Core.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private Vector3 startPosition;
    private bool dead = false;
    public UnityEvent OnDead;

    [SerializeField] private float closeness = 2f;
    [SerializeField] private float chaseRange = 10f;
    [SerializeField] private float attackRange = 3f;

    [SerializeField]
    private List<GameObject> faces;

    [SerializeField]
    private GameObject disappearParticle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindFirstObjectByType<HVRPlayerController>().transform;
        startPosition = transform.position;
    }
    private void Update()
    {
        if (dead) return;

        float distance = (player.position - transform.position).magnitude;
        if (distance > chaseRange)
        {
            Patrol();
        }
        else if (distance <= chaseRange && distance > attackRange)
        {
            Chase();
        }
        else if (distance <= attackRange)
        {
            Attack();
        }
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);
    }

    private void Attack()
    {
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);
    }

    private void Chase()
    {
        agent.destination = player.position - (player.position - transform.position).normalized * closeness;
    }

    private void Patrol()
    {
        //agent.destination = startPosition;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "projectile" && dead == false)
        {
            GetComponent<Animator>().SetTrigger("Dance");
            faces[Random.Range(0, faces.Count)].SetActive(true);
            dead = true;
            StartCoroutine(Disappear());
            OnDead.Invoke();
        }

    }

    private IEnumerator Disappear()
    {
        yield return new WaitForSeconds(10);
        GameObject.Instantiate(disappearParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
