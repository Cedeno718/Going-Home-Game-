using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Required for TextMeshPro components

public class FishManager : MonoBehaviour
{
    public int fishCount;
    public TextMeshProUGUI fishText; // Correct capitalization here

    void Start()
    {
        // Initialize fish count or text display if needed
        fishText.text = "Fish Count: " + fishCount.ToString();
    }

    void Update()
    {
        // Update the text to reflect the current fish count
        fishText.text = "Fish Count: " + fishCount.ToString();
    }
}
