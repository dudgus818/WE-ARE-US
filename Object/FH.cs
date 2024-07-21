using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FH : MonoBehaviour //P2 발판
{
    GameObject player1;
    GameObject player2;
    Rigidbody foothold2_RB;
    public GameObject die;
    string a = "Player1";
    string b = "Player2";
    string die1 = "die";
    // Start is called before the first frame update
    void Start()
    {
        
        foothold2_RB = GetComponent<Rigidbody>();
        die = GameObject.FindGameObjectWithTag(die1);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == player2.tag)
        {
            foothold2_RB.isKinematic = true;
        }
        else if (collision.collider.tag == player1.tag)
        {
            foothold2_RB.isKinematic = false;
            Debug.Log("플2");
        }
        if (collision.collider.tag == die1)
        {
            Debug.Log("사라짐");
            GameObject.Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        player1 = GameObject.FindWithTag(a);
        player2 = GameObject.FindWithTag(b);
    }
}
