using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMent : MonoBehaviour
{
    [SerializeField] private GameObject[] points;
    [SerializeField] private float speed = 2f;//�ƶ��ٶ�
    private int pointNum = 1;//��ʼ�ƶ�Ŀ��
    

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, points[pointNum].transform.position, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, points[pointNum].transform.position) < 0.1f)
        {
            pointNum++;
            pointNum %= 2;
        }
    }
}
