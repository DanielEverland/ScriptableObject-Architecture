using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventListener<T>
{
    void OnEventRaised(T value);
}
public interface IGameEventListener
{
    void OnEventRaised();
}
