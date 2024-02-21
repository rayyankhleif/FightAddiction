using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    // Use an array to store multiple URLs
    public string[] urlsToOpen;

    // Assuming you're using the UI system for the button
    public UnityEngine.UI.Button yourButton;

    void Start()
    {
        // Make sure to attach this script to a GameObject with a Button component
        yourButton.onClick.AddListener(OpenUrlOnClick);
    }

    public void OpenUrlOnClick()
    {
        // Choose a random URL from the array or modify as needed
        string randomUrl = urlsToOpen[Random.Range(0, urlsToOpen.Length)];
        Application.OpenURL(randomUrl);
    }
}
