using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AnimationController : MonoBehaviour
{
    public Transform target;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.DOMove(new Vector3(1.5f, 0, 0), 2);
            
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.DOMove(new Vector3(0, 0, 0), 2);

        }

    }
}