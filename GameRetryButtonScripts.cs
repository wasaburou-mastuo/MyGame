using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRetryButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickGameRetryButton()
    {
        print("���g���C");
        SceneManager.LoadScene("GameScene");

    }
}
