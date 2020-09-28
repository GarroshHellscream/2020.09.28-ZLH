using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class WaitUtil : INotifyCompletion
{
    WaitObject owner;
    float seconds = -1;

    bool isCompleted = false;
    public bool IsCompleted
    {
        get
        {
            return isCompleted;
        }
    }

    bool isStarted = false;
    public bool IsStarted
    {
        get
        {
            return isStarted;
        }
    }

    public WaitUtil(float seconds)
    {
        this.seconds = seconds;
    }

    public void OnCompleted(Action continuation)
    {

    }


    public void WaitTime()
    {
        isStarted = true;
        isCompleted = false;
    }

    public void Update(float deltaTime)
    {
        if (isStarted && !isCompleted)
        {
            if (seconds > 0)
            {
                seconds -= deltaTime;
            }
            else
            {
                isCompleted = true;
            }
        }
    }

    public WaitUtil GetAwaiter()
    {
        return this;
    }

    public WaitUtil GetResult()
    {
        return this;
    }
}
