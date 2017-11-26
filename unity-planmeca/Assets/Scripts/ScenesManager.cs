using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{

    public bool switch_to_drill = false;
    public bool switch_to_main = false;



    private void Update()
    {
         if (switch_to_drill)
        {
            Application.LoadLevel(1);
            //ScenesManager.LoadScene(1);
        }

        else if (switch_to_main)
        {
            Application.LoadLevel(0);
        }

    }

}
