using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Particle_Controller : MonoBehaviour
{
    public GameObject water;
    //public AudioSource audioSource;


    
    //Start関数より最初に実行される関数
    //何かのコンポーネントの取得処理でよく使う。
    private void Awake()
    {

        //ホースを持っている状態かどうかをゲットコンポーネントで取得
    }
    //Awake()中の値を変更したい時や、初期化するときにStartに書く。
    // Start is called before the first frame update
    void Start()
    {

    }


    //Shoot();出し始める処理
    //ShootEnd();出し終わる処理
    // Update is called once per frame
    void Update()
    {

        Shoot();
        ShootEnd();
    }

    //今度ホースを持っているか、持っていないかという条件を付ける
    void Shoot()
    {

        //左クリックしている間、水を出し、オーディオAを再生
        if (Input.GetMouseButton(0))
        {
            water.SetActive(true);
            //audioSource.Play();
        }
    }

    void ShootEnd()
    {
        //左クリックを離したとき、水が消え、オーディオAも消える
        if (Input.GetMouseButtonUp(0))
        {
            water.SetActive(false);
            //audioSource.Stop();
        }

    }
}
