using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimationController : MonoBehaviour
{

    public GameObject floor1, floor2;
    Vector3 F1Initial, F2Initial;
    public static int activeFloor = 0;

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

    public void OnSelect1()
    {
            ZoomFloor1();
    }

    public void OnSelect2()
    {
        ZoomFloor2();
    }

    public void OnSelectReset()
    {
        ShiftRight();
    }

    public void ShiftRight()
    {
        activeFloor = 0;
        floor1.SetActive(true);
        floor1.transform.position = F1Initial;
        floor2.transform.position = F2Initial;
        floor2.transform.DOScale(new Vector3(1, 1, 1), 1);
        floor2.transform.DOMove(new Vector3(1.5f, 0, 1.5f), 2);
    }

    public void ShiftLeft()
    {
        activeFloor = 0;
        floor1.SetActive(true);
        floor1.transform.position = F1Initial;
        floor2.transform.position = F2Initial;
        floor2.transform.DOScale(new Vector3(1, 1, 1), 1);
        floor2.transform.DOMove(new Vector3(0, 0, 1.5f), 2);
    }

    public void ZoomFloor1()
    {
        activeFloor = 1;
        floor1.SetActive(false);
        floor2.SetActive(false);
        floor2.transform.DOMove(new Vector3(6f, -2f, 1.5f), 2);
        floor2.transform.DOScale(new Vector3(20, 20, 20), 2);

    }

    public void ZoomFloor2()
    {
        activeFloor = 2;
        floor2.SetActive(true);
        floor1.SetActive(false);
        floor2.transform.DOMove(new Vector3(6f, -2f, 1.5f), 2);
        floor2.transform.DOScale(new Vector3(20, 20, 20), 2);
       
    }

}