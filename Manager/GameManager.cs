using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject[] playerIMG1;
    public GameObject[] playerIMG2;
    public GameObject[] player;
    public static int p1=0;
    public static int p2 =1;
    public bool choseT = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        player[0].GetComponent<Player>().a = p1;
        player[1].GetComponent<Player2>().a2 = p2;
        if (choseT)
        {
            player[0].GetComponent<Player>().GetComponentInChildren<Movement3D3>().isMove = false;
            player[1].GetComponent<Player2>().GetComponentInChildren<Movement3D>().isMove = false;
            playerIMG1[p1].SetActive(true);
            playerIMG2[p2].SetActive(true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (p1>=0)
                    {
                        if (p1 != 0)
                        {
                            playerIMG1[p1].SetActive(false);
                            if (p1 == p2+1 & p1 != 1)
                            {
                                p1 -= 2;
                            }
                            else if (p1 == p2 + 1 & p1 == 1) { }
                            else { p1 -= 1;}
                            playerIMG1[p1].SetActive(true);
                        }
                    }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(p1 <= 7)
                {
                    if (p1 != 7) 
                    {
                        playerIMG1[p1].SetActive(false);
                     
                        if (p1 == p2-1& p1 != 6)
                        {
                            p1 += 2;
                        }
                        else if (p1 == p2 - 1 & p1 == 6) { }
                        else {p1 += 1;}
                        playerIMG1[p1].SetActive(true);
                    }
                }
            
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (p2 >= 0)
                {
                    if (p2 != 0)
                    {
                        playerIMG2[p2].SetActive(false);
                        if (p2 == p1 + 1 & p2 != 1)
                        {
                            p2 -= 2;
                        }
                        else if(p2 == p1 + 1 & p2 == 1){ }
                        else { p2 -= 1; }
                        playerIMG2[p2].SetActive(true);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (p2 <= 7)
                {
                    if (p2 != 7)
                    {
                        playerIMG2[p2].SetActive(false);

                        if (p2 == p1 - 1 & p2 != 6)
                        {
                            p2 += 2;
                        }
                        else if (p2 == p1 - 1 & p2 == 6) { }
                        else { p2 += 1; }
                        playerIMG2[p2].SetActive(true);
                    }
                }

            }
        }
        if (choseT == false)
        {
            playerIMG1[p1].SetActive(false);
            playerIMG2[p2].SetActive(false);
            player[0].GetComponent<Player>().GetComponentInChildren<Movement3D3>().isMove = true;
            player[1].GetComponent<Player2>().GetComponentInChildren<Movement3D>().isMove = true;
        }
    }
}
