using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_Particle_Controller : MonoBehaviour
{
    public GameObject water;
    //public AudioSource audioSource;


    
    //Start�֐����ŏ��Ɏ��s�����֐�
    //�����̃R���|�[�l���g�̎擾�����ł悭�g���B
    private void Awake()
    {

        //�z�[�X�������Ă����Ԃ��ǂ������Q�b�g�R���|�[�l���g�Ŏ擾
    }
    //Awake()���̒l��ύX����������A����������Ƃ���Start�ɏ����B
    // Start is called before the first frame update
    void Start()
    {

    }


    //Shoot();�o���n�߂鏈��
    //ShootEnd();�o���I��鏈��
    // Update is called once per frame
    void Update()
    {

        Shoot();
        ShootEnd();
    }

    //���x�z�[�X�������Ă��邩�A�����Ă��Ȃ����Ƃ���������t����
    void Shoot()
    {

        //���N���b�N���Ă���ԁA�����o���A�I�[�f�B�IA���Đ�
        if (Input.GetMouseButton(0))
        {
            water.SetActive(true);
            //audioSource.Play();
        }
    }

    void ShootEnd()
    {
        //���N���b�N�𗣂����Ƃ��A���������A�I�[�f�B�IA��������
        if (Input.GetMouseButtonUp(0))
        {
            water.SetActive(false);
            //audioSource.Stop();
        }

    }
}
