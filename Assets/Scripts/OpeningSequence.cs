using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;

public class OpeningSequence : MonoBehaviour
{
    public GameObject Player;
    public GameObject TextBox;
    public GameObject FadeInScreen;
    public GameObject Crosshair;
    public AudioSource HorrorAmbientSound;
    public AudioSource VoiceActing01;
    public VideoPlayer openingVideo;
    public RawImage videoPanel;

    void Start()
    {
        Player.GetComponent<FirstPersonController>().enabled = false;
        Crosshair.SetActive(false);
        TextBox.SetActive(false);
        FadeInScreen.SetActive(true);
        StartCoroutine(PlayFirstSequence());

    }

    public IEnumerator PlayFirstSequence()
    {
        //preparing the opening video for use.
        openingVideo.Prepare();
        yield return new WaitForSeconds(1f);
        while (!openingVideo.isPrepared) {
            yield return new WaitForSeconds(1f);
        }
        //setting the texture of the raw image same as video.
        videoPanel.texture = openingVideo.texture;
        openingVideo.Play();
        HorrorAmbientSound.Play();
        VoiceActing01.Play();
        yield return new WaitForSeconds(23f);
        //the opening sequence has finished,time to disable video,raw images.
        openingVideo.Stop();
        videoPanel.enabled = false;
        FadeInScreen.GetComponent<Animation>().Play();
        FadeInScreen.SetActive(false);
        //Initializing the players UI.
        TextBox.SetActive(true);
        yield return new WaitForSeconds(2f);
        TextBox.SetActive(false);
        Crosshair.SetActive(true);
        Player.GetComponent<FirstPersonController>().enabled = true;
        

    }

}