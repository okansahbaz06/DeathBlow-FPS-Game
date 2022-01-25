using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public int can;
    public GameObject olum;
    public GameObject yokol;
    public Slider canbar;
    void Start()
    {
        olum.SetActive(false);
    }

    // Update is called once per frame
    public void hasar(int deger)
    {
        
        if(can >= 0)
        {
            can -= deger;
        }
        if(can == 0)
        {
            yokol.SetActive(false);
            olum.SetActive(true);
            Time.timeScale = 0;
            
        }
        canbar.value = can;
    }

    void FixedUpdate()
    {
        
    }

}
