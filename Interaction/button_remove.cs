using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_remove : MonoBehaviour //P1¿ë
{
    GameObject player1;
    GameObject player2;
    public GameObject re_target;
    string a = "Player1";

    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == a)
        {
            re_target.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
