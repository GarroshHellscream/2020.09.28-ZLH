using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    TaskBase parallTask;
    TaskBase serialTask;

    private void Start()
    {
        StartSerialTask();
        StartParallTask();
    }

    async void StartSerialTask()
    {
        serialTask = new TaskParall(new TaskBase[] { new TaskWaitFrame(1000), new TaskWaitTime(2) });
        Debug.Log("Start serial task");
        await serialTask.Start();
        Debug.Log("End serial task");
    }

    async void StartParallTask()
    {
        parallTask = new TaskParall(new TaskBase[] {new TaskWaitFrame(300), new TaskWaitTime(2) });
        Debug.Log("Start parall task");
        await parallTask.Start();
        Debug.Log("End parall task");
    }

    //调用Cancel()以取消任务
    void Update()
    {
        Debug.Log("New frame");
        if (!parallTask.IsCompleted)
        {
            parallTask.UpdatePerFrame(Time.deltaTime);
        }

        if (!serialTask.IsCompleted)
        {
            serialTask.UpdatePerFrame(Time.deltaTime);
        }
    }

}
