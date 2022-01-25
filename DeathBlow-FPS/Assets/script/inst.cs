using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class inst : MonoBehaviour
{
    public GameObject kup1;

    public GameObject tree;

    
    // Start is called before the first frame update
    void Start()
    {

        /*System.Random rastgele = new System.Random();

        for (int i = 0; i < 15; i++)
        {
            int sayi1 = rastgele.Next(1,10);
            
            int sayi3 = rastgele.Next(1,30);
            
            Vector3 pos = new Vector3(sayi1, 3, sayi3);
            Vector3 pos2 = new Vector3(sayi3, 0,sayi1 );
            Instantiate(kup1, pos, transform.rotation);
            Instantiate(tree, pos2, transform.rotation);
        }
        */

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Random.Range(-10, 10), 3, Random.Range(-10, 10));
        //Vector3 pos = new Vector3(8, 6, 3);
        //Vector3 pos1 = new Vector3(3, 6, 4);
        if (Input.GetKeyDown(KeyCode.K))
            Instantiate(kup1, pos, transform.rotation);

        Vector3 pos2 = new Vector3(Random.Range(-40, 40), 0, Random.Range(-40, 40));
        if (Input.GetKeyDown(KeyCode.T))
            Instantiate(tree, pos2, transform.rotation);
    }
}
