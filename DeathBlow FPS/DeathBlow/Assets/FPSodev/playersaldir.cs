using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playersaldir : MonoBehaviour
{
    public Player pr;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            pr.hasar(20);
            

        }
    }
}
