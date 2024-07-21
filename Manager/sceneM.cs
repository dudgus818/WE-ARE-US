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
    public void Load_menuCam_Scene()   //���Ӹ޴� ī�޶� �ҷ����� �Լ�
    {
        gameManager.GetComponent<GameManager>().choseT = false;
        mainCam.GetComponent<CamCont>().b = false;
        mainCam.GetComponent<CamCont>().c = false;
        mainCam.GetComponent<CamCont>().a = true;
        Debug.Log("�޴�");
        rd_ui.SetActive(false);
        md_ui.SetActive(false);
        op_ui.SetActive(true);
    }
    public void Load_choseCam_Scene()   //���ӷ��� ī�޶� �ҷ����� �Լ�
    {
        gameManager.GetComponent<GameManager>().choseT = true;
        mainCam.GetComponent<CamCont>().a = false;
        mainCam.GetComponent<CamCont>().c = false;
        mainCam.GetComponent<CamCont>().b = true;
        Debug.Log("����");
        op_ui.SetActive(false);
        md_ui.SetActive(false);
        rd_ui.SetActive(true);
    }
    public void Load_mdCam_Scene()   //���ӷ��� ī�޶� �ҷ����� �Լ�
    {
        gameManager.GetComponent<GameManager>().choseT = false;
        mainCam.GetComponent<CamCont>().a = false;
        mainCam.GetComponent<CamCont>().b = false;
        mainCam.GetComponent<CamCont>().c = true;
        Debug.Log("���");
        rd_ui.SetActive(false);
        op_ui.SetActive(false);
        md_ui.SetActive(true);
    }
    public void Load_menu_Scene()   //���Ӹ޴� ���� �ҷ����� �Լ�
    {
        SceneManager.LoadScene("Start");
    }
    public void Load_tu_game_Scene() //���� ���� �ҷ����� �Լ�
    {
        SceneManager.LoadScene("tu");
    }
    public void Load_TA_game_Scene() //���� ���� �ҷ����� �Լ�
    {
        SceneManager.LoadScene("timeattack");
    }
    public void Quit_Game() //���ӿ��� ������ �Լ�
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
