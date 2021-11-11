using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloorController : MonoBehaviour
{
    public List<GameObject> TargetCursors;
  　
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnActiveCursor(bool active=true) 
    {

       
        // Active Cursors
        foreach(GameObject obj in TargetCursors)
        {
            if (obj == null)
            {
                continue; //１行if文　nulならば処理をしない。すべてnullなら何も処理しないという書き方。
            }
            if( active)
            {
                obj.GetComponent<LockON>().CursorActive();
            }
            else
            {
                obj.GetComponent<LockON>().CursorInactive();
            }
        }

        //print("OnActiveCurosr");
    }
    
    /*
     private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision=" + collision  );
        
        if (collision.gameObject.name == "Firemans_Hose")
        {
            Debug.Log("OK");
            //cursor.GetComponent<LockON>().CursorActive();

        }

    }*/
}
