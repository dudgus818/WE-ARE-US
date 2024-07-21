using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneM : MonoBehaviour
{
    public GameObject op_ui;
    public GameObject rd_ui;
    public GameObject md_ui;
    public Camera mainCam;
    public GameManager gameManager;
    public void Load_menuCam_Scene()   //게임메뉴 카메라를 불러오는 함수
    {
        gameManager.GetComponent<GameManager>().choseT = false;
        mainCam.GetComponent<CamCont>().b = false;
        mainCam.GetComponent<CamCont>().c = false;
        mainCam.GetComponent<CamCont>().a = true;
        Debug.Log("메뉴");
        rd_ui.SetActive(false);
        md_ui.SetActive(false);
        op_ui.SetActive(true);
    }
    public void Load_choseCam_Scene()   //게임레디 카메라를 불러오는 함수
    {
        gameManager.GetComponent<GameManager>().choseT = true;
        mainCam.GetComponent<CamCont>().a = false;
        mainCam.GetComponent<CamCont>().c = false;
        mainCam.GetComponent<CamCont>().b = true;
        Debug.Log("츄즈");
        op_ui.SetActive(false);
        md_ui.SetActive(false);
        rd_ui.SetActive(true);
    }
    public void Load_mdCam_Scene()   //게임레디 카메라를 불러오는 함수
    {
        gameManager.GetComponent<GameManager>().choseT = false;
        mainCam.GetComponent<CamCont>().a = false;
        mainCam.GetComponent<CamCont>().b = false;
        mainCam.GetComponent<CamCont>().c = true;
        Debug.Log("모드");
        rd_ui.SetActive(false);
        op_ui.SetActive(false);
        md_ui.SetActive(true);
    }
    public void Load_menu_Scene()   //게임메뉴 씬을 불러오는 함수
    {
        SceneManager.LoadScene("Start");
    }
    public void Load_tu_game_Scene() //게임 씬을 불러오는 함수
    {
        SceneManager.LoadScene("tu");
    }
    public void Load_TA_game_Scene() //게임 씬을 불러오는 함수
    {
        SceneManager.LoadScene("timeattack");
    }
    public void Quit_Game() //게임에서 나가는 함수
    {
        Application.Quit();
    }
    public void Load_option_true()
    {
        op_ui.SetActive(true);
    }
    public void Load_option_false()
    {
        op_ui.SetActive(false);
    }

}
