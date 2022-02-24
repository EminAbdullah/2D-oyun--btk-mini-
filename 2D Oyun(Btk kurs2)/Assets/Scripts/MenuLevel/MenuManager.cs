using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject DataBoard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("InGameScene");

    }

    public void DataBoardButton()
    {
        DataManager.Instance.loadData();

        DataBoard.transform.GetChild(1).GetComponent<Text>().text ="Total Bullet Shot = " + DataManager.Instance.totalShotBullet.ToString();
        DataBoard.transform.GetChild(2).GetComponent<Text>().text= "Total Enemy Killed = " + DataManager.Instance.TotalEnemyKilled.ToString();     
        DataBoard.SetActive(true);
    }

    public void DataBoardClose()
    {

        DataBoard.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
