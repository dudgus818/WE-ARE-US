using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCont : MonoBehaviour
{
    Vector3 menu = new Vector3(14.76f, 4.77f, -3.327f);
    Vector3 chose = new Vector3(14.76f, 4.77f, 2.058f);
    Vector3 ready = new Vector3(18.28f, 5.24f, 2.5f);
    Vector3 Menu_Chose_ro = new Vector3(0, 0, 0);
    Vector3 ready_ro = new Vector3(20.513f, -124.509f, 2.096f);

    public bool a=false;
    public bool b =false;
    public bool c=false;

    // Update is called once per frame
    void Update()
    {
        if (a == true)
        {
            transform.eulerAngles = Menu_Chose_ro;
            transform.position += (menu - transform.position) * 0.02f;
        }

        if (b == true)
        {
            transform.eulerAngles = Menu_Chose_ro;

            transform.position += (chose - transform.position) * 0.02f;
        }
        if (c == true)
        {
            transform.eulerAngles = ready_ro;

            transform.position += (ready - transform.position) * 0.02f;

        }
    }
}
