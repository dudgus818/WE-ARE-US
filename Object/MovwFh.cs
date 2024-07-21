using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MovwFh : MonoBehaviour
{
    public float speed=1;
    bool check = true;
    public GameObject endFH;
    public GameObject startFH;
    Rigidbody Z_FH;

    // Start is called before the first frame update
    void Start()
    {
        Z_FH = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.tag == endFH.tag)
        {
            check =false;
        }
        if (collision.rigidbody.tag == startFH.tag)
        {
            check = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (check == true)
        {
            transform.position += new Vector3(0, 0, 0.4f)*speed;
        }
               
        if (check == false)
        {
            transform.position -= new Vector3(0, 0, 0.4f) * speed;
        }
    }
}
