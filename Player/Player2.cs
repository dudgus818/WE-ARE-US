using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public GameObject[] p2_img;
    public int a2 = 1;
    int b2 = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        a2 = GameManager.p2;
        if (a2 != b2)
        {
            p2_img[b2].SetActive(false);
            p2_img[a2].SetActive(true);
            b2 = a2;
        }
    }
}
