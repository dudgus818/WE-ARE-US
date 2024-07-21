using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{

    public Rigidbody rb;
    public float range = 1f;
    public float jumpAmount = 35;
    public bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Jumppad")
        {
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse); //충돌시 점프
        }
           
    }

        IEnumerator JumpBool()
        {

            grounded = true;
            yield return new WaitForSeconds(0.1f);
            grounded = false;
        }
    }

