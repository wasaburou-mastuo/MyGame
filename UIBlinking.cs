using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBlinking : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        time += Time.deltaTime;
        print(time);
        if (time >= 3.0f)
        {
            print("OK");
            Destroy(this.gameObject);
        }
    }
}
