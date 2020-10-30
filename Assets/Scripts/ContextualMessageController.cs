using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContextualMessageController : MonoBehaviour
{
    // Start is called before the first frame update

    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;
    }

    private void ShowMessage(string message, float duration)
    {
        messageText.text = message;
    }
}   
