using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScripts : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("GameScene");

    }
}
