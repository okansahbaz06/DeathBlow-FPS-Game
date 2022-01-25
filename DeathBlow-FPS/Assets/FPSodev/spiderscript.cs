using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spiderscript : MonoBehaviour
{

    Animator Spideranim;

    public Transform Hedef;
    NavMeshAgent Agent;
    public float mesafe;
    public float can;
    void Start()
    {

        Spideranim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Spideranim.SetFloat("hız2", Agent.velocity.magnitude);

        Spideranim.SetFloat("can2", can);

        mesafe = Vector3.Distance(transform.position, Hedef.position);

        if (can > 0)
        {
            if (mesafe <= 15)
            {
                Agent.enabled = true;
                Agent.destination = Hedef.position;
            }
            else
            {
                Agent.enabled = false;
            }
        }
        else
        {
            Destroy(gameObject, 5f);
        }
    }
}
