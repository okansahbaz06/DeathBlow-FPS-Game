using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saldiri : MonoBehaviour
{
    public zombiescript zs;
    public Animator anim;
    bool sal;
    void Start()
    {
        
    }
    public void saldir()
    {
        if (sal == true)
        {
            if(zs.mesafe >= 2)
            {
                anim.SetBool("saldir", false);
                zs.Agentac();
                
            }
            anim.SetBool("saldir", true);
            zs.Agentkapa();
            StartCoroutine(saldirizmn());
           
          
        }
        sal = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sal = true;
            saldir();
            



        }
    }
    IEnumerator saldirizmn()

    {
        yield return new WaitForSeconds(2.7f);
        
        anim.SetBool("saldir", false);
        

        zs.Agentac();
        sal = true;
        saldir();

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("saldir", false);
            zs.Agentac();
            
            
        }
    }


}
