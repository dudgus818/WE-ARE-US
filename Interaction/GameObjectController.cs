using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameObjectController : MonoBehaviour
{
    public Text text;
    public Transform PlayerCenter;
    public Transform PlayerCenter1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerCenter.position.x <= 4 && PlayerCenter.position.z >= 130 && PlayerCenter1.position.x <= 4 && PlayerCenter1.position.z >= 130)
        {
            text.text = " " + 0.ToString("Game Clear\n press 'R' to next stage");
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Start");
            }
        }
        
    }
}
