using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_attive : MonoBehaviour //P2¿ë
{
    GameObject player2;
    public GameObject at_target;
    string a = "Player2";


    // Start is called before the first frame update
    void Start()
    {
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == player2.tag)
        {
            at_target.GetComponent<Clicker>().ismove = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        player2 = GameObject.FindWithTag(a);
    }
}
