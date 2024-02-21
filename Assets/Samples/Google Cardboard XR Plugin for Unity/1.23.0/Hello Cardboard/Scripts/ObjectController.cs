using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class ObjectController : MonoBehaviour
{
    //public Material InactiveMaterial;
    //public Material GazedAtMaterial;
    public Animator Anim;
    public AudioClip mySound;
    public AudioClip secondSound;
    public AudioClip thirdSound; // AudioClip field for the third sound
    public AudioClip fourthSound; // AudioClip field for the fourth sound
    public AudioClip fifthSound; // AudioClip field for the fifth sound
    public AudioClip sixthSound; // AudioClip field for the sixth sound
    public AudioClip seventhSound; // AudioClip field for the seventh sound
    public AudioClip eighthSound; // AudioClip field for the eighth sound
    public AudioClip ninthSound; // AudioClip field for the ninth sound
    public VideoClip videoClip; // The video clip to be played on third touch
    public VideoClip newVideoClip; // New video clip to be played on fifth touch
    public VideoClip seventhVideoClip; // New video clip to be played on seventh touch
    public VideoClip ninthVideoClip; // New video clip to be played on ninth touch
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component for playing the video
    public VideoPlayer newVideoPlayer; // Reference to the second VideoPlayer component for playing the new video
    public VideoPlayer seventhVideoPlayer; // Reference to the third VideoPlayer component for playing the seventh video
    public VideoPlayer ninthVideoPlayer; // Reference to the fourth VideoPlayer component for playing the ninth video

    private int interactionCount = 0;
    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
        //SetMaterial(false);

        // Assign the video clip to the VideoPlayer
        if (videoClip != null)
        {
            videoPlayer.clip = videoClip;
        }

        // Ensure the video doesn't play on awake
        videoPlayer.playOnAwake = false;

        // Assign the render texture to the VideoPlayer
        videoPlayer.targetTexture = new RenderTexture(1, 1, 24);

        // Assign the new video clip to the second VideoPlayer
        if (newVideoClip != null)
        {
            newVideoPlayer.clip = newVideoClip;
        }

        // Ensure the new video doesn't play on awake
        newVideoPlayer.playOnAwake = false;

        // Assign the render texture to the second VideoPlayer
        newVideoPlayer.targetTexture = new RenderTexture(1, 1, 24);

        // Assign the seventh video clip to the third VideoPlayer
        if (seventhVideoClip != null)
        {
            seventhVideoPlayer.clip = seventhVideoClip;
        }

        // Ensure the seventh video doesn't play on awake
        seventhVideoPlayer.playOnAwake = false;

        // Assign the render texture to the third VideoPlayer
        seventhVideoPlayer.targetTexture = new RenderTexture(1, 1, 24);

        // Assign the ninth video clip to the fourth VideoPlayer
        if (ninthVideoClip != null)
        {
            ninthVideoPlayer.clip = ninthVideoClip;
        }

        // Ensure the ninth video doesn't play on awake
        ninthVideoPlayer.playOnAwake = false;

        // Assign the render texture to the fourth VideoPlayer
        ninthVideoPlayer.targetTexture = new RenderTexture(1, 1, 24);
    }

    public void TeleportRandomly()
    {
        Anim.SetBool("isTalking",true);
        /*

        
        int sibIdx = transform.GetSiblingIndex();
        int numSibs = transform.parent.childCount;
        sibIdx = (sibIdx + Random.Range(1, numSibs)) % numSibs;
        GameObject randomSib = transform.parent.GetChild(sibIdx).gameObject;

        float angle = Random.Range(-Mathf.PI, Mathf.PI);
        float distance = Random.Range(_minObjectDistance, _maxObjectDistance);
        float height = Random.Range(_minObjectHeight, _maxObjectHeight);
        Vector3 newPos = new Vector3(Mathf.Cos(angle) * distance, height,
                                     Mathf.Sin(angle) * distance);

        transform.parent.localPosition = newPos;

        randomSib.SetActive(true);
        gameObject.SetActive(false);
        */
        //SetMaterial(false);
    }

    public void OnPointerEnter()
    {
        interactionCount++;
        

        switch (interactionCount)
        {
            case 1:
                Anim.SetBool("isTalking",true);
                //myAnimation.Play();
                AudioSource.PlayClipAtPoint(mySound, transform.position);
                break;
               
            case 2:
                Anim.SetBool("isTalking",true);
               // myAnimation.Play();
                AudioSource.PlayClipAtPoint(secondSound, transform.position);
                break;
            case 3:
                Anim.SetBool("isTalking",true);
                AudioSource.PlayClipAtPoint(thirdSound, transform.position);
                if (videoPlayer != null)
                {
                    videoPlayer.Play();
                }
                break;
            case 4:
                Anim.SetBool("isTalking",true);
                AudioSource.PlayClipAtPoint(fourthSound, transform.position);
                break;
            case 5:
                Anim.SetBool("isTalking",true);
                AudioSource.PlayClipAtPoint(fifthSound, transform.position);
                if (videoPlayer != null)
                {
                    videoPlayer.Stop();
                }
                if (newVideoPlayer != null)
                {
                    newVideoPlayer.Play();
                }
                break;
            case 6:
                Anim.SetBool("isTalking",true);
                AudioSource.PlayClipAtPoint(sixthSound, transform.position);
                break;
            case 7:
                Anim.SetBool("isTalking",true);
                AudioSource.PlayClipAtPoint(seventhSound, transform.position);

                // Stop previous video
                if (newVideoPlayer != null)
                {
                    newVideoPlayer.Stop();
                }

                // Play the new video using the third VideoPlayer component
                if (seventhVideoPlayer != null)
                {
                    seventhVideoPlayer.Play();
                }
                break;
            case 8:
                Anim.SetBool("isTalking",true);
                AudioSource.PlayClipAtPoint(eighthSound, transform.position);
                break;
            case 9:
                Anim.SetBool("isTalking",true);
                AudioSource.PlayClipAtPoint(ninthSound, transform.position);

                // Stop previous video
                if (seventhVideoPlayer != null)
                {
                    seventhVideoPlayer.Stop();
                }

                // Play the new video using the fourth VideoPlayer component
                if (ninthVideoPlayer != null)
                {
                    ninthVideoPlayer.Play();
                }
                break;
            default:
                break;
        }

       // SetMaterial(true);
    }

    public void OnPointerExit()
    {
        Anim.SetBool("isTalking",false);
        //SetMaterial(false);
    }

    public void OnPointerClick()
    {
        TeleportRandomly();
    }

    //private void SetMaterial(bool gazedAt)
   // {
       // if (InactiveMaterial != null && GazedAtMaterial != null)
       /// {
       //     _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
       // }
    //}
}
