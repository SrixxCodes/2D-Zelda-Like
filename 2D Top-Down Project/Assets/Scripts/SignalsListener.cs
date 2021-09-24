using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalsListener : MonoBehaviour
{
    public Signals signals;
    public UnityEvent signalsEvent;

    public void OnSignalsRaised()
    {
        signalsEvent.Invoke();
    }

    private void OnEnable()
    {
        signals.RegisterListener(this);
    }

    private void OnDisable()
    {
        signals.DeRegisterListener(this);
    }

}
