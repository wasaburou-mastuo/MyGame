using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReturnTitleButtonScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickStarGameReturnTitle()
    {
        SceneManager.LoadScene("Title");

    }
}
