using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimationController : MonoBehaviour
{

    public GameObject floor1;
    Vector3 F1Initial, F2Initial;

    // Use this for initialization
    void Start()
    {
        F1Initial = floor1.transform.position;
        F2Initial = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            ShiftLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            ShiftRight();
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            ZoomFloor2();
        }
    //x 0.041894 y -0.568 z 0.75762  s 25

}

    public void OnSelect()
    {
        ZoomFloor2();
    }

    public void ShiftRight()
    {
        floor1.SetActive(true);
        floor1.transform.position = F1Initial;
        transform.position = F2Initial;
        transform.DOScale(new Vector3(1, 1, 1), 1);
        transform.DOMove(new Vector3(1.5f, 0, 1.5f), 2);
    }

    public void ShiftLeft()
    {
        floor1.SetActive(true);
        floor1.transform.position = F1Initial;
        transform.position = F2Initial;
        transform.DOScale(new Vector3(1, 1, 1), 1);
        transform.DOMove(new Vector3(0, 0, 1.5f), 2);
    }

    public void ZoomFloor2()
    {
            floor1.SetActive(false);
            transform.DOMove(new Vector3(6f, -2f, 1.5f), 2);
            transform.DOScale(new Vector3(25, 25, 25), 2);
       
    }
}