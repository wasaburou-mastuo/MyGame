using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ // ゲームオブジェクトを格納する変数
    public GameObject gameObject;
    // ゲームオブジェクトの回転速度を格納する変数
    public Vector2 rotationSpeed;
    // マウス移動方向とゲームオブジェクト回転方向を反転する判定フラグ
    public bool reverse;
    // マウス座標を格納する変数
    private Vector2 lastMousePosition;
    // ゲームオブジェクトの角度を格納する変数（初期値に0,0を代入）
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
        NORMAL,     //０番
        GAMEOVER,　//1番
    }
    public MODE nowMode = MODE.NORMAL;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

    }
    // ゲーム実行中の繰り返し処理
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


        // 左クリックした時
        if (Input.GetMouseButtonDown(0))
        {
            // ゲームオブジェクトの角度を変数"newAngle"に格納（マウスクリックしたところの座標（角度）が代入される）
            newAngle = gameObject.transform.localEulerAngles;
            //Debug.Log(newAngle);
            // マウス座標を変数"lastMousePosition"に格納
            lastMousePosition = Input.mousePosition;
            //Debug.Log(lastMousePosition);
        }
        // 左ドラッグしている間
        else if (Input.GetMouseButton(0))
        {
            //オブジェクト回転方向の判定フラグが"true"の場合
            if (!reverse)
            {
                // Y軸の回転：マウスドラッグ方向に視点回転
                // マウスの水平移動値に変数"rotationSpeed"を掛ける
                //（クリック時の座標とマウス座標の現在値の差分値）
                newAngle.y -= (lastMousePosition.x - Input.mousePosition.x) * rotationSpeed.y;
                // X軸の回転：マウスドラッグ方向に視点回転
                // マウスの垂直移動値に変数"rotationSpeed"を掛ける
                //（クリック時の座標とマウス座標の現在値の差分値）
                newAngle.x -= (Input.mousePosition.y - lastMousePosition.y) * rotationSpeed.x;
                // "newAngle"の角度をカメラ角度に格納
                gameObject.transform.localEulerAngles = newAngle;
                // マウス座標を変数"lastMousePosition"に格納
                lastMousePosition = Input.mousePosition;
            }
            // カメラ回転方向の判定フラグが"reverse"の場合
            else if (reverse)
            {
                // Y軸の回転：マウスドラッグと逆方向に視点回転
                newAngle.y -= (Input.mousePosition.x - lastMousePosition.x) * rotationSpeed.y;
                // X軸の回転：マウスドラッグと逆方向に視点回転
                newAngle.x -= (lastMousePosition.y - Input.mousePosition.y) * rotationSpeed.x;
                // "newAngle"の角度をカメラ角度に格納
                gameObject.transform.localEulerAngles = newAngle;
                // マウス座標を変数"lastMousePosition"に格納
                lastMousePosition = Input.mousePosition;
            }
        }
    }

    // マウスドラッグ方向と視点回転方向を反転する処理
    public void DirectionChange()
    {
        // 判定フラグ変数"reverse"が"false"であれば
        if (!reverse)
        {
            // 判定フラグ変数"reverse"に"true"を代入
            reverse = true;
        }
        // でなければ（判定フラグ変数"reverse"が"true"であれば）
        else
        {
            // 判定フラグ変数"reverse"に"false"を代入
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
