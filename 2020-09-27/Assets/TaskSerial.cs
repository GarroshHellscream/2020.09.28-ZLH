using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSerial : TaskBase
{
    TaskBase[] taskArray;
    TaskBase currentTask;
    int currentIndex = 0;

    public TaskSerial(TaskBase[] taskArray)
    {
        this.taskArray = taskArray;
        if(taskArray.Length>0)
            currentTask = taskArray[currentIndex];
        NewTaskNode();
    }

    async void NewTaskNode()
    {
        await currentTask.Start();
    }

    public override void UpdatePerFrame(float deltaTime)
    {
        if (currentTask.IsCompleted)
        {
            currentIndex++;
            if (currentIndex < taskArray.Length)
            {
                currentTask = taskArray[currentIndex];
                NewTaskNode();
            }
            else
            {
                Finish();
            }
        }
        currentTask.UpdatePerFrame(deltaTime);
    }
}