using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour {

    public Button StartButton;
    public AudioSource StartSound;
    void Start()
    {
        StartButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        StartCoroutine(StartTheGame());
    }

    IEnumerator StartTheGame() {
        StartSound.Play();
        yield return new WaitForSeconds(2.8f);
        SceneManager.LoadScene("Scene01");
    }
}
