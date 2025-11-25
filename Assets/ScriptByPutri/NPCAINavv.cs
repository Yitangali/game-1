using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAINavv : MonoBehaviour
{
    public GameObject theDestination;
    NavMeshAgent theAgent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      theAgent = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        theAgent.SetDestination(theDestination.transform.position);
    }
}
