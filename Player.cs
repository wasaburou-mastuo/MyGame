using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ // �Q�[���I�u�W�F�N�g���i�[����ϐ�
    public GameObject gameObject;
    // �Q�[���I�u�W�F�N�g�̉�]���x���i�[����ϐ�
    public Vector2 rotationSpeed;
    // �}�E�X�ړ������ƃQ�[���I�u�W�F�N�g��]�����𔽓]���锻��t���O
    public bool reverse;
    // �}�E�X���W���i�[����ϐ�
    private Vector2 lastMousePosition;
    // �Q�[���I�u�W�F�N�g�̊p�x���i�[����ϐ��i�����l��0,0�����j
    private Vector2 newAngle = new Vector2(0, 0);
  

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public GameObject corsor;
    public GameObject corsor2;
    public GameObject corsor3;

    public enum MODE
    {
        NORMAL,     //�O��
        GAMEOVER,�@//1��
    }
    public MODE nowMode = MODE.NORMAL;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    // �Q�[�����s���̌J��Ԃ�����
    void Update()
    {
        if (MODE.GAMEOVER == nowMode) return;

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);


        // ���N���b�N������
        if (Input.GetMouseButtonDown(0))
        {
            // �Q�[���I�u�W�F�N�g�̊p�x��ϐ�"newAngle"�Ɋi�[�i�}�E�X�N���b�N�����Ƃ���̍��W�i�p�x�j����������j
            newAngle = gameObject.transform.localEulerAngles;
            //Debug.Log(newAngle);
            // �}�E�X���W��ϐ�"lastMousePosition"�Ɋi�[
            lastMousePosition = Input.mousePosition;
            //Debug.Log(lastMousePosition);
        }
        // ���h���b�O���Ă����
        else if (Input.GetMouseButton(0))
        {
            //�I�u�W�F�N�g��]�����̔���t���O��"true"�̏ꍇ
            if (!reverse)
            {
                // Y���̉�]�F�}�E�X�h���b�O�����Ɏ��_��]
                // �}�E�X�̐����ړ��l�ɕϐ�"rotationSpeed"���|����
                //�i�N���b�N���̍��W�ƃ}�E�X���W�̌��ݒl�̍����l�j
                newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
                // X���̉�]�F�}�E�X�h���b�O�����Ɏ��_��]
                // �}�E�X�̐����ړ��l�ɕϐ�"rotationSpeed"���|����
                //�i�N���b�N���̍��W�ƃ}�E�X���W�̌��ݒl�̍����l�j
                newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;
                // "newAngle"�̊p�x���J�����p�x�Ɋi�[
                gameObject.transform.localEulerAngles = newAngle;
                // �}�E�X���W��ϐ�"lastMousePosition"�Ɋi�[
                lastMousePosition = Input.mousePosition;
            }
            // �J������]�����̔���t���O��"reverse"�̏ꍇ
            else if (reverse)
            {
                // Y���̉�]�F�}�E�X�h���b�O�Ƌt�����Ɏ��_��]
                newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * rotationSpeed.y;
                // X���̉�]�F�}�E�X�h���b�O�Ƌt�����Ɏ��_��]
                newAngle.x -= (lastMousePosition.y - Input.mousePosition.y) * rotationSpeed.x;
                // "newAngle"�̊p�x���J�����p�x�Ɋi�[
                gameObject.transform.localEulerAngles = newAngle;
                // �}�E�X���W��ϐ�"lastMousePosition"�Ɋi�[
                lastMousePosition = Input.mousePosition;
            }
        }
    }

    // �}�E�X�h���b�O�����Ǝ��_��]�����𔽓]���鏈��
    public void DirectionChange()
    {
        // ����t���O�ϐ�"reverse"��"false"�ł����
        if (!reverse)
        {
            // ����t���O�ϐ�"reverse"��"true"����
            reverse = true;
        }
        // �łȂ���΁i����t���O�ϐ�"reverse"��"true"�ł���΁j
        else
        {
            // ����t���O�ϐ�"reverse"��"false"����
            reverse = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Floor_A")
        {
            Debug.Log("OK");
            //if (null == other.gameObject.GetComponent<FloorController>()) return;

            other.gameObject.GetComponent<FloorController>().OnActiveCursor();

            //corsor.GetComponent<LockON>().CursorActive();
            //corsor2.GetComponent<LockON>().CursorActive();
            //corsor3.GetComponent<LockON>().CursorActive();
        }

        if (other.gameObject.name == "Floor_B")
        {
            other.gameObject.GetComponent<FloorController>().OnActiveCursor();
        }

        if (other.gameObject.name == "Floor_C")
        {
            other.gameObject.GetComponent<FloorController>().OnActiveCursor();
        }
        if (other.gameObject.name == "Floor_C (2)")
        {
            other.gameObject.GetComponent<FloorController>().OnActiveCursor();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Floor_A")
        {
            Debug.Log("OK");
            other.gameObject.GetComponent<FloorController>().OnActiveCursor(false);
            //corsor.GetComponent<LockON>().CursorInactive();
            //corsor2.GetComponent<LockON>().CursorInactive();
            //corsor3.GetComponent<LockON>().CursorInactive();
        }
        
        if (other.gameObject.name == "Floor_B")
        {
            other.gameObject.GetComponent<FloorController>().OnActiveCursor(false);
        }

        if (other.gameObject.name == "Floor_C")
        {
            other.gameObject.GetComponent<FloorController>().OnActiveCursor(false);
        }

        if (other.gameObject.name == "Floor_C (2)")
        {
            other.gameObject.GetComponent<FloorController>().OnActiveCursor(false);
        }

    }

}
