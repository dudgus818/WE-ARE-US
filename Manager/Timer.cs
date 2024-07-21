using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    private float done = 60.0F;
    private Rigidbody charRigidbody;
    public Text text;
    public Transform PlayerCenter;
    
    //public Transform target;
    // Use this for initialization

    void Start()
    {
        

    }


    // Update is called once per frame

    void Update()
    {

        if (done > 0F  )
        {
            
            done -= Time.deltaTime;
            
            text.text = " " + Mathf.Round(done);
            //SceneManager.LoadScene("gameclear");
        }
        else if(done < 0F)
        {


            text.text = " " + done.ToString("Game Over\n press 'F' to restart" );
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("timeattack");
            }
               
            // transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);
        }
       if(PlayerCenter.position.x <= 10 && PlayerCenter.position.z >= 157)
        {

            text.text = " " + done.ToString("Game Clear \n press 'R' to next Stage");
           if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Start");
            }
           // transform.RotateAround(target.position, Vector3.up, 20 * Time.deltaTime);
        }
        


    }
   
}

