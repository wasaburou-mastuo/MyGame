using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{

    private float time = 120.0f;
    public TextMeshProUGUI timerText;
    public Text missionText;
    public bool isTimeUp;
    //private int mission = 5;
    public GameObject gameOverText;
    public Player player;
    public Water_Particle_Controller water_Particle_Controller;
    public GameObject GameRetryOBJ;
    public GameObject GameReturnTitleOBJ;


    // Start is called before the first frame update
    void Start()
    {
        isTimeUp = false;
        //GameRetryOBJ = GameObject.Find("GameRetry");
        //GameReturnTitleOBJ = GameObject.Find("GameReturnTitle");
        Debug.Log(GameRetryOBJ);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeUp) return;
        
        if (0 < time)
        {
            time -= Time.deltaTime;
            timerText.text = "残り時間  " + time.ToString("F1") + "秒";
            
        }
        else if(time<0)
        {
            isTimeUp = true;
            gameOverText.GetComponent<GameOver>().GameOverText();
            player.nowMode = Player.MODE.GAMEOVER;
            //ボタンを二つ表示する！！リトライとタイトルボタン。
            GameRetryOBJ.SetActive(true);
            GameReturnTitleOBJ.SetActive(true);


        }

        //missionText.text = "残りミッション　" + mission;
    }
}
