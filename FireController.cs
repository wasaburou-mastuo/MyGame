using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ignis;

public class FireController : MonoBehaviour
{
    public int HP = 3;
    //float fireSpreadDamage;
    float fireHP;
    // Start is called before the first frame update
    void Start()
    {
        
        //HPが１減った時のダメージを変数に入れる。可変なのでmaxSpreadが１万とかでもちゃんとダメージ分減らしてくれる。
        //fireSpreadDamage = GetComponent<FlammableObject>().maxSpread / HP;

        fireHP = GetComponent<FlammableObject>().flameVFXMultiplier;
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (HP <= 0)
        {
            fireHP -= 0.02f;
            GetComponent<FlammableObject>().flameVFXMultiplier = fireHP;
            //Debug.Log("入りました= " + fireHP);

            if (fireHP < -10)
            {
                //print("HP "+HP);
                GetComponent<FlammableObject>().enabled = false;
            }
            //スクリプトをenableで無効化できる。
            //GetComponent<FlammableObject>().enabled=false;
            //GetComponent<FlammableObject>().burnOutStart_s = 10;
        }
        
    }
    
    public void Damege()
    {
        HP--;
        print("damage HP "+HP);
        //変数にすることでより、プログラマー的な書き方になる。
        //fireSpreadだけだと、一瞬消えるがまた燃え盛る。
        //GetComponent<FlammableObject>().fireSpread -= fireSpreadDamage * 2;
        //GetComponent<FlammableObject>().maxSpread -= fireSpreadDamage;

    }
    
}
