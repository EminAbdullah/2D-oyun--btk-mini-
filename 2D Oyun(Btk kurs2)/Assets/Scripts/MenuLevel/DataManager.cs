using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int TotalEnemyKilled;

    EasyFileSave myFile;
    void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET  = " + shotBullet.ToString();
        }
        
    }
    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED  = " + enemyKilled.ToString();
        }
    
    }

    void StartProcess()
    {
        myFile = new EasyFileSave();
        loadData();
    }

    public void SaveData()
    {
        totalShotBullet += shotBullet;
        TotalEnemyKilled += enemyKilled;
        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", TotalEnemyKilled);

        myFile.Save();
    }
    public void loadData()
    {
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            TotalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }
}
