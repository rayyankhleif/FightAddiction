using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class ObjectController1 : MonoBehaviour
{
    public VideoClip videoClip; // The video clip to be played

    private VideoPlayer _videoPlayer;
    private bool _hasStarted = false; // Track if the video has started playing

    private void Start()
    {
        // Get the VideoPlayer component or add it if not present
        _videoPlayer = GetComponentInChildren<VideoPlayer>();
        if (_videoPlayer == null)
        {
            _videoPlayer = gameObject.AddComponent<VideoPlayer>();
        }

        // Assign the video clip to the VideoPlayer
        if (videoClip != null)
        {
            _videoPlayer.clip = videoClip;
        }

        // Ensure the video doesn't play on awake
        _videoPlayer.playOnAwake = false;
        _videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Do something when the video ends (if needed)
    }

    public void TeleportRandomly()
    {
        // Teleport logic...
    }

    public void OnPointerEnter()
    {
        // Play the video when gazed at if it hasn't started already
        if (_videoPlayer != null && !_hasStarted)
        {
            _videoPlayer.Play();
            _hasStarted = true;
        }
    }

    public void OnPointerExit()
    {
        // Stop the video when not gazed at
        if (_videoPlayer != null)
        {
            _videoPlayer.Stop();
        }
    }

    public void OnPointerClick()
    {
        TeleportRandomly();
    }
}
