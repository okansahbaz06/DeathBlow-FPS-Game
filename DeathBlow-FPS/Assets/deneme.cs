using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;




public class deneme : MonoBehaviour
{


    void uret(int x, int y, int z)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.GetComponent<Rigidbody>();
        cube.transform.position = new Vector3(x, y, z);
    }
    void uret2(int x, int y, int z)
    {
        GameObject kapsul = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        kapsul.GetComponent<Rigidbody>();
        kapsul.transform.position = new Vector3(x, y, z);
    }



    void Start()
    {

       
        String veri = File.ReadAllText(@"c:\deneme.txt");

        int m = 0, j = 0;

        int[,] dizi = new int[9, 4];

        foreach (var row in veri.Split('\n'))
        {
            j = 0;
            foreach (var col in row.Trim().Split(' '))
            {
                dizi[m, j] = int.Parse(col.Trim());
                j++;
            }
            m++;
        }


        for (int i = 0; i < 9; i++)
        {
            for (int k = 0; k < 4; k++)
            {
                

                if (dizi[i, k]==-1)
                {
                    //Debug.Log(dizi[i, k]);
                    int x = dizi[i, 1];
                    int y = dizi[i, 2];
                    int z = dizi[i, 3];
                    uret(x, y, z);
                    

                }
                if (dizi[i, k] == -2)
                {
                    //Debug.Log(dizi[i, k]);
                    int x = dizi[i, 1];
                    int y = dizi[i, 2];
                    int z = dizi[i, 3];
                    uret2(x, y, z);


                }


            }
        }













    }










    void Update()
    {

    }
}