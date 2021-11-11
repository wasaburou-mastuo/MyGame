using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockON : MonoBehaviour
{
    [SerializeField] GameObject target;
    
    //[SerializeField] Vector3 offset = new Vector3(0,0.1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //画像を燃えるオブジェクトに付いているターゲットに動かしたい。
        //イメージはスクリーン座標
        //オブジェクトはワールド座標
        //transform.position = target.transform.position;
        transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.transform.position);
    }

    /*
    CursorActive(); //trueが入る
    CursorActive(false);    //falseが入る
    */

    public void CursorActive(bool active = true )
    {
        this.gameObject.SetActive(active);
    }

    public void CursorInactive()
    {
        this.gameObject.SetActive(false);
    }

}


