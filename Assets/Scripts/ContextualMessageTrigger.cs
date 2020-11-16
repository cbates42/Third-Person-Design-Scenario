using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualMessageTrigger : MonoBehaviour
{
    [SerializeField]
    private string message = "Placeholder";
    [SerializeField]
    private float duration = 1.0f;
   



    public static event Action<string, float> ContextualMessageTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (ContextualMessageTriggered != null)
            {
                ContextualMessageTriggered.Invoke(message, duration);
            }

        }
    }




}
