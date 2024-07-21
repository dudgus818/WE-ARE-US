using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public float Starttime;
    public float minX, maxX;
    public float minY, maxY;
    public float minZ, maxZ;

    [Range(1,100)]

    public float moveSpeed;

    private int sign = -1; //좌
    private int signY = -1; //아래
    private int signZ = -1; 

    public bool ismove =false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ismove)
        {
            if(Time.time >= Starttime)
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, moveSpeed * Time.deltaTime * signY, moveSpeed * Time.deltaTime * signZ);
                //이동 로직 처리

                if(transform.position.x <= minX || transform.position.x >= maxX&&maxX!=0&&minX!=0)
                {
                    sign *= -1;
                    Debug.Log("X");
                }
                else if(maxX == 0 && minX == 0)
                {
                    sign = 0;
                }
                if (transform.position.y <= minY || transform.position.y >= maxY && maxY != 0 && minY != 0)
                {
                    signY *= -1;
                    Debug.Log("Y");
                }
                else if (maxY == 0 && minY == 0)
                {
                    signY = 0;
                }

                if (transform.position.z <= minZ || transform.position.z >= maxZ && maxZ != 0 && minZ != 0)
                {
                    signZ *= -1;
                    Debug.Log("Z");
                }
                else if (maxZ == 0 && minZ == 0)
                {
                    signZ = 0;
                }
            }
        }
        
    }
}
