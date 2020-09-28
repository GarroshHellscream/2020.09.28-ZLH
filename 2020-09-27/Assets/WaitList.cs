using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using UnityEngine;

public class WaitList: INotifyCompletion
{
    float seconds;
    Action continua;

    bool isCompleted = false;
    public bool IsCompleted
    {
        get
        {
            return isCompleted;
        }
    }
    bool canceled = false;

    

    public WaitList GetAwaiter() => this;

    public WaitList GetResult()
    {
        if (canceled)
        {
            throw new Exception("canceled");
        }
        return this;
    }

    void Cancel()
    {
        canceled = true;
        continua();
    }

    public void UpdateTime(float deltaTime)
    {
        if (seconds < 0)
        {
            isCompleted = true;
            continua();
        }
        seconds -= deltaTime;
    }

    public WaitList WaitStart(float seconds)
    {
        this.seconds = seconds;
        
        return this;
    }

    public void OnCompleted(Action continua)
    {
        this.continua = continua;
    }
}
