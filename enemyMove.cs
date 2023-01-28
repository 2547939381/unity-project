using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    private float startTime;
    private float endTime;

    float start_x;
    float end_x;

   
    private void FixedUpdate()
    {
        startTime = Time.time;
        Debug.Log(startTime + "aaaaaaaaaaa");
        start_x = transform.position.x;
        //Invoke("getPosition", 0.02f);
        do
        {
            endTime = Time.time;
            if (startTime - endTime >= 0.1f)
            {
                break;
            }
            //Debug.Log(endTime + "b");
        } while (startTime - endTime < 0.1f);//延迟0.02s后再获取位置
        Debug.Log(endTime + "bbbbbbbbbb");
        if (startTime - endTime > 0.02f)
        {
            //Debug.Log("xxx");
        }
        getPosition();

        Debug.Log(start_x+"a");
        Debug.Log(end_x+"b");

        if (end_x - start_x > 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //Debug.Log("1");
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            //Debug.Log("2");
        }
    }
    
    private void getPosition()
    {
        end_x = transform.position.x;
        //Debug.Log("3");
    }
        
        
}
