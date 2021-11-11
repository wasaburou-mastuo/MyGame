using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGameManager : MonoBehaviour
{

    int ClearCount;
    [SerializeField] List<GameObject> RoomControllerObjects;
    public GameObject gameClearText;
    public GameObject GameRetryOBJ;
    public GameObject GameReturnTitleOBJ;
    //public GameObject clearObj;
    //public int HP;

    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (var v in RoomControllerObjects)
        {
            clearObj.GetComponent<RoomManager>().targetObjects;
        }
        */

        //clearObj.GetComponent<RoomManager>().GetHP(); 　一部屋分のターゲットの数を取得

        ClearCount = RoomControllerObjects.Count;


        //一つずつvar型のｖに入れていく。
        foreach (var v in RoomControllerObjects)
        {
            ClearCount += v.GetComponent<RoomManager>().GetHP();
        }

        //print("---ClearCount" + ClearCount);

        
    }


    private void Update()
    {
        
    }

    public void ClearGame()
    {
        ClearCount--;
       
        if(ClearCount <= 0)
        {
            Debug.Log("ゲームクリア");
            gameClearText.GetComponent<GameClear>().GameClearText();
            //タイトルへ戻るボタンを作成
            GameRetryOBJ.SetActive(true);
            GameReturnTitleOBJ.SetActive(true);

        }
    }
}
