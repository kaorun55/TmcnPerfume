using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if WINDOWS_UWP
using UnityEngine.XR.WSA.Input;
#endif

public class Motion : MonoBehaviour {

#if WINDOWS_UWP
    GestureRecognizer recogniszer;
#endif

    public GameObject aachan;
    public GameObject kashiyuka;
    public GameObject nocchi;

	// Use this for initialization
	void Start () {
#if WINDOWS_UWP
        recogniszer = new GestureRecognizer();
        recogniszer.SetRecognizableGestures(GestureSettings.Tap);

        recogniszer.TappedEvent += Recogniszer_TappedEvent;
        recogniszer.StartCapturingGestures();
#endif
    }

#if WINDOWS_UWP
    private void Recogniszer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
    {
        StartDansing();
    }
#endif

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartDansing();
        }
    }

    private void StartDansing()
    {
        aachan.GetComponent<Animator>().Play("animation");
        kashiyuka.GetComponent<Animator>().Play("animation");
        nocchi.GetComponent<Animator>().Play("animation");

        GetComponent<AudioSource>().Play();
    }
}
