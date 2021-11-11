using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    int GameEndCount;
    [SerializeField]  List<GameObject> targetObjects;
    public GameObject clearOBJ;
    int targetCount;
    public GameObject cursorFalse;


    private void Awake()
    {
        //GameEndCount = 1;

    }
    // Start is called before the first frame update
    //自分以外のComponentの取得など
    void Start()
    {
        
        targetCount = targetObjects.Count;
        print("targetCount" + targetCount);

        
    }

    public int GetHP() //この関数を作ってあげることで、９行目をPublicに変えずに、関数で targetObjectsの数を返すことができる。
    {
        return targetObjects.Count;
    }

   
    public void CheckTarget()       //TargetControllerスクリプトでターゲットが非表示になったら呼び出し。
    {
        targetCount--;
        Debug.Log(targetCount);
        if (targetCount <= 0)
        {
            //Debug.Log("CheckTarget");
            GameCountCheck();
        }
    }
   

    void GameCountCheck()    //各ルームのターゲットが０（全て非アクティブ）になったら－１する。
    {
        
        GameEndCount--;
        Debug.Log(GameEndCount);
        if(GameEndCount <= 0)
        {
            //ここでゲーム終了
            Debug.Log("カウント");
            clearOBJ.GetComponent<ClearGameManager>().ClearGame();

            foreach(GameObject obj in cursorFalse.GetComponent<FloorController>().TargetCursors)
            {
                Destroy(obj);
            }
           //Destroy(cursorFalse.GetComponent<FloorController>().TargetCursors);

        }
    }



    
    void CheckTargets() //ここで、targetがアクティブか、非アクティブかを判定。
    {
        foreach(GameObject obj in targetObjects)
        {
            Debug.Log(obj);
            if(obj.activeSelf == false) //ここでターゲットが非アクティブなら以下の処理を行うようにする。
            {
                //ここで非アクティブならカウントを－１にする
                targetCount--;
                //Debug.Log(targetCount);
                if(targetCount == 0)
                {
                    GameCountCheck();
                }

            }
        }
    }
    

}
