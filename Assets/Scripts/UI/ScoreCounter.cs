using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text counterText;
    public int targetValue;
    public UnityEvent allTargetsDestroyed;
    int counter = 0;

    private void Start()
    {
        counterText.text = "Targets hit: " + counter.ToString();
    }
    
    public void onTargetHit()
    {
        counter++;
        counterText.text = "Targets hit: " + counter.ToString();
        if (counter == targetValue)
            allTargetsDestroyed?.Invoke();
    }
}
