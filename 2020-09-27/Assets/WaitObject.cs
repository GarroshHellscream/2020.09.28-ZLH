using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WaitObject : MonoBehaviour
{
    WaitList waitList;
    // Start is called before the first frame update
    async void Start()
    {
        waitList = new WaitList();
        Debug.Log("Start");
        await waitList.WaitStart(0.2f);
        Debug.Log("End");
    }

    // Update is called once per frame
    void Update()
    {
        //if(!waitList.IsCompleted)
            waitList.UpdateTime(Time.deltaTime);
    }

}
