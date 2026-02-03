using UnityEngine;
using UnityEngine.Video;

public class Animations : MonoBehaviour
{
    [SerializeField] string videoFileName;

    private VideoPlayer videoPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
    }
}
