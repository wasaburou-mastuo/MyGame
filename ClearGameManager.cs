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

        //clearObj.GetComponent<RoomManager>().GetHP(); �@�ꕔ�����̃^�[�Q�b�g�̐����擾

        ClearCount = RoomControllerObjects.Count;


        //�����var�^�̂��ɓ���Ă����B
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
            Debug.Log("�Q�[���N���A");
            gameClearText.GetComponent<GameClear>().GameClearText();
            //�^�C�g���֖߂�{�^�����쐬
            GameRetryOBJ.SetActive(true);
            GameReturnTitleOBJ.SetActive(true);

        }
    }
}
