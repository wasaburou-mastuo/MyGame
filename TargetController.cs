using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    float time = 0.1f;
    public GameObject ObjParent;
    public float shrinkSpeed ;   //ターゲットが縮小するスピード
    Vector3 targetScale;　//標的の大きさを入れる変数
    bool isDamege;　//bool型の変数isDamege(デフォルトはfalse）
    public GameObject gameManagerObj;
    ClearGameManager clearGameMng; //ClearGameManager型の変数を作成


    // Start is called before the first frame update
    void Start()
    {
        targetScale = gameObject.transform.localScale; //標的の大きさを変数に代入

        /*  ２行での書き方
        GameObject tmp = GameObject.Find("ClearGameManager");　//オブジェクトを取得
        clearGameMng = tmp.GetComponent<ClearGameManager>();　//スクリプトを取得
        */
        clearGameMng = GameObject.Find("ClearGameManager").GetComponent<ClearGameManager>();　　//ClearGmaeManagerスクリプトを取得
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    private void OnDisable()    //ここで、非アクティブを検知
    {
        //Debug.Log("disable");
        clearGameMng.ClearGame();
        gameManagerObj.GetComponent<RoomManager>().CheckTarget();
    }


    private void OnParticleCollision(GameObject other)
    {
        time -= Time.deltaTime;
        //Debug.Log(time);
        ScaleChange();

        if (time <= 0 && !isDamege)     //タイムが０以下かつisDamegeがfalseでないなら、以下を実行。
        {

            //print(ObjParent + "へダメージを与える処理");
            //ObjParent.GetComponent<FireController>().HP --;
            //上のは省略系、読み下すと以下の２文になる。
            //FireController fCtrl = ObjParent.GetComponent<FireController>();
            //fCtrl.HP--;
            isDamege = true;　//変数isDamegeにtrueを代入

            Debug.Log("damege -- from : "+gameObject.name);     //呼び出し元（このスクリプトがアタッチされている）のゲームオブジェクトを表示
            ObjParent.GetComponent<FireController>().Damege();
            //Destroy(this.gameObject);   
            this.gameObject.SetActive(false);
        }

    }
    void ScaleChange()
    {


        //Debug.Log("ScaleChange");
        targetScale.x -= shrinkSpeed;
        targetScale.y -= shrinkSpeed;
        targetScale.z -= shrinkSpeed;


        transform.localScale = targetScale;

    }
}
