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
        
        //HP���P���������̃_���[�W��ϐ��ɓ����B�ςȂ̂�maxSpread���P���Ƃ��ł������ƃ_���[�W�����炵�Ă����B
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
            //Debug.Log("����܂���= " + fireHP);

            if (fireHP < -10)
            {
                //print("HP "+HP);
                GetComponent<FlammableObject>().enabled = false;
            }
            //�X�N���v�g��enable�Ŗ������ł���B
            //GetComponent<FlammableObject>().enabled=false;
            //GetComponent<FlammableObject>().burnOutStart_s = 10;
        }
        
    }
    
    public void Damege()
    {
        HP--;
        print("damage HP "+HP);
        //�ϐ��ɂ��邱�Ƃł��A�v���O���}�[�I�ȏ������ɂȂ�B
        //fireSpread�������ƁA��u�����邪�܂��R������B
        //GetComponent<FlammableObject>().fireSpread -= fireSpreadDamage * 2;
        //GetComponent<FlammableObject>().maxSpread -= fireSpreadDamage;

    }
    
}
