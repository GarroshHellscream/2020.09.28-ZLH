using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskWaitTime : TaskBase
{
    float seconds;

    public TaskWaitTime(float seconds)
    {
        this.seconds = seconds;
    }

    public override void UpdatePerFrame(float deltaTime)
    {
        if (seconds <= 0)
        {
            Finish();
        }
        seconds -= deltaTime;
    }
}