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
        //�摜��R����I�u�W�F�N�g�ɕt���Ă���^�[�Q�b�g�ɓ����������B
        //�C���[�W�̓X�N���[�����W
        //�I�u�W�F�N�g�̓��[���h���W
        //transform.position = target.transform.position;
        transform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.transform.position);
    }

    /*
    CursorActive(); //true������
    CursorActive(false);    //false������
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


