using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Player : MonoBehaviour
{
    public GameObject[] p1_img;
    
    public int a =0;
    int b = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a = GameManager.p1;
        
        if (a != b)
        {
            p1_img[b].SetActive(false);
            p1_img[a].SetActive(true);
            b = a;
        }
    }
}
