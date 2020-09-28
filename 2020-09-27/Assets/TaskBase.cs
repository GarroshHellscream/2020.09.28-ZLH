using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using System;


public class TaskBase : INotifyCompletion
{
    public Action continua;

    bool isCompleted = false;
    public bool IsCompleted
    {
        get
        {
            return isCompleted;
        }
    }
    bool canceled = false;

    

    public TaskBase GetAwaiter() => this;

    public TaskBase GetResult()
    {
        return this;
    }

    protected void Finish()
    {
        isCompleted = true;
        if(continua != null)
            continua();
    }

    public void Cancel()
    {
        isCompleted = true;
        canceled = true;
        continua();
    }

    public virtual void UpdatePerFrame(float deltaTime)
    {

    }

    public virtual TaskBase Start()
    {
        return this;
    }

    public void OnCompleted(Action continua)
    {
        this.continua = continua;
    }
}
