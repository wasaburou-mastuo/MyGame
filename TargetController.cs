using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    float time = 0.1f;
    public GameObject ObjParent;
    public float shrinkSpeed ;   //�^�[�Q�b�g���k������X�s�[�h
    Vector3 targetScale;�@//�W�I�̑傫��������ϐ�
    bool isDamege;�@//bool�^�̕ϐ�isDamege(�f�t�H���g��false�j
    public GameObject gameManagerObj;
    ClearGameManager clearGameMng; //ClearGameManager�^�̕ϐ����쐬


    // Start is called before the first frame update
    void Start()
    {
        targetScale = gameObject.transform.localScale; //�W�I�̑傫����ϐ��ɑ��

        /*  �Q�s�ł̏�����
        GameObject tmp = GameObject.Find("ClearGameManager");�@//�I�u�W�F�N�g���擾
        clearGameMng = tmp.GetComponent<ClearGameManager>();�@//�X�N���v�g���擾
        */
        clearGameMng = GameObject.Find("ClearGameManager").GetComponent<ClearGameManager>();�@�@//ClearGmaeManager�X�N���v�g���擾
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    private void OnDisable()    //�����ŁA��A�N�e�B�u�����m
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

        if (time <= 0 && !isDamege)     //�^�C�����O�ȉ�����isDamege��false�łȂ��Ȃ�A�ȉ������s�B
        {

            //print(ObjParent + "�փ_���[�W��^���鏈��");
            //ObjParent.GetComponent<FireController>().HP --;
            //��̂͏ȗ��n�A�ǂ݉����ƈȉ��̂Q���ɂȂ�B
            //FireController fCtrl = ObjParent.GetComponent<FireController>();
            //fCtrl.HP--;
            isDamege = true;�@//�ϐ�isDamege��true����

            Debug.Log("damege -- from : "+gameObject.name);     //�Ăяo�����i���̃X�N���v�g���A�^�b�`����Ă���j�̃Q�[���I�u�W�F�N�g��\��
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
