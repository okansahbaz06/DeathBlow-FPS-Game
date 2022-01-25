using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class zombiescript : MonoBehaviour
{

    Animator Zombieanim;
    
    public Transform Hedef;
    NavMeshAgent Agent;
    public float mesafe;
    public float health;
    public float intsayac;
    public Text sayac;
    public int can;
    public GameObject kazandiniz;
    public GameObject colider;

    void Start()
    {
        kazandiniz.SetActive(false);
        intsayac = 0;
        colider.SetActive(false);
        Zombieanim = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Zombieanim.SetFloat("hız", Agent.velocity.magnitude);

        Zombieanim.SetFloat("can", health);

        sayac.text = intsayac.ToString();

        mesafe = Vector3.Distance(transform.position, Hedef.position);

        if (health > 0)
        {
            if(mesafe >= 2)
            {
                colider.SetActive(false);
                Zombieanim.SetBool("saldir", false);
            }
            else
            {
                colider.SetActive(true);
            }
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
        else if (health == 0)
        {
            oldu();
        }
      
        

    }
    public void oldu()
    {
        kazandiniz.SetActive(true);
        intsayac++;
        Destroy(gameObject, 3f);
    }
    public void can1(int amount)
    {
        if(health<=0)
        {
            Debug.Log("a");
        }
        if (health >= 0)
        {
            health -= amount;
        }
        
        
    }
    
    public void Agentac()
    {
        Agent.enabled = true;
    }
    public void Agentkapa()
    {
        Agent.enabled = false;
    }
}
