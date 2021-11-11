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
    //�����ȊO��Component�̎擾�Ȃ�
    void Start()
    {
        
        targetCount = targetObjects.Count;
        print("targetCount" + targetCount);

        
    }

    public int GetHP() //���̊֐�������Ă����邱�ƂŁA�X�s�ڂ�Public�ɕς����ɁA�֐��� targetObjects�̐���Ԃ����Ƃ��ł���B
    {
        return targetObjects.Count;
    }

   
    public void CheckTarget()       //TargetController�X�N���v�g�Ń^�[�Q�b�g����\���ɂȂ�����Ăяo���B
    {
        targetCount--;
        Debug.Log(targetCount);
        if (targetCount <= 0)
        {
            //Debug.Log("CheckTarget");
            GameCountCheck();
        }
    }
   

    void GameCountCheck()    //�e���[���̃^�[�Q�b�g���O�i�S�Ĕ�A�N�e�B�u�j�ɂȂ�����|�P����B
    {
        
        GameEndCount--;
        Debug.Log(GameEndCount);
        if(GameEndCount <= 0)
        {
            //�����ŃQ�[���I��
            Debug.Log("�J�E���g");
            clearOBJ.GetComponent<ClearGameManager>().ClearGame();

            foreach(GameObject obj in cursorFalse.GetComponent<FloorController>().TargetCursors)
            {
                Destroy(obj);
            }
           //Destroy(cursorFalse.GetComponent<FloorController>().TargetCursors);

        }
    }



    
    void CheckTargets() //�����ŁAtarget���A�N�e�B�u���A��A�N�e�B�u���𔻒�B
    {
        foreach(GameObject obj in targetObjects)
        {
            Debug.Log(obj);
            if(obj.activeSelf == false) //�����Ń^�[�Q�b�g����A�N�e�B�u�Ȃ�ȉ��̏������s���悤�ɂ���B
            {
                //�����Ŕ�A�N�e�B�u�Ȃ�J�E���g���|�P�ɂ���
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
