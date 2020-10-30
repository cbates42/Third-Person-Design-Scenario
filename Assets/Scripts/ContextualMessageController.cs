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

    private IEnumerator ShowMessage(string message, float duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;
        //wait for the duration
        yield return new WaitForSeconds(duration);
        canvasGroup.alpha = 0;
    }
}   
