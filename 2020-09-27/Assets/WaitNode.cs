using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitNode
{
    WaitList owner;
    public WaitNode(WaitList owner)
    {
        this.owner = owner;
    }

}
