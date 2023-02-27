﻿using UnityEngine;
using UnityEngine.AI;
using UnityEditor;
using System.Collections;
public class ZombieController : MonoBehaviour
{
    private NavMeshAgent _agent;

    private GameObject _player;

    private GameObject _brain;

    private GameObject _destination;

    // The distance used by the zombie to find a target
    public float smellSense = 5;

    private GameObject[] _destinations;

    // A state that shows if the zombie is seeking the player
    private bool _isSeeking;

    IEnumerator SetNextDestination()
    {
        int index = Random.Range(0, _destinations.Length);
        _destination = _destinations[index];
        _agent.destination = _destination.transform.position;

        yield return new WaitForSeconds(3f); 
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _player = GameObject.FindGameObjectWithTag("Player");

        _brain = GameObject.FindGameObjectWithTag("Collectable");

        _destinations = GameObject.FindGameObjectsWithTag("Destination");

        StartCoroutine(SetNextDestination());
    }

    private void Update()
    {
        var distanceToBrain = Vector3.Distance(transform.position, _brain.transform.position);

        var distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        // If the player is within range ...
        if (distanceToPlayer < smellSense)
        {
            // ... move toward the player, updating the destination each frame
            _agent.destination = _player.transform.position;
            _isSeeking = true;
        }
        else
        {
            _isSeeking = false;

            var distanceToDestination = Vector3.Distance(transform.position, _destination.transform.position);
            if (distanceToDestination > .5f)
            {
                SetNextDestination();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Depending on the status, change the handles color
        if(_isSeeking)
        {
            Handles.color = new Color(1f, 0f, 0f, 0.1f);
            Gizmos.color = new Color(1f, 0f, 0f, 0.1f);
        }
        else
        {
            Handles.color = new Color(0f, 1f, 0f, 0.1f);
            Gizmos.color = new Color(0f, 1f, 0f, 0.1f);
        }
        // Draw a disc displaying the smell sense range for the zombie
        Handles.DrawSolidDisc(transform.position,Vector3.up, smellSense);
        
        Gizmos.DrawSphere(transform.position, smellSense);
    }
}
