using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    public GameObject kup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = new Vector3(Random.Range(-8,8),6,Random.Range(-8,8));
        Vector3 pos = new Vector3(8, 6, 3);
        Vector3 pos1 = new Vector3(3, 6, 4);
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(kup, pos, transform.rotation);
    }
}
