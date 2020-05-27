using UnityEngine;
using System.Collections;
//This script controls the buttons and sounds depending on which ui has been pressed
public class InterfaceAudio : MonoBehaviour {
	
	public AudioClip clickButtonAudio;
	public AudioClip clickPlayButtonAudio;
	public AudioClip clickCloseButtonAudio;
	public AudioClip clickCloseHUDButtonAudio;

    //referance to the volume
    public float audioVolume;

    //Gets Referances to the Audio of buttons
    private AudioSource clickButtonAudioSource;

	void Awake(){
		clickButtonAudioSource = GetComponent<AudioSource>();
	}

    //Each function plays a differant sound when a programmed  Ui is pressed
    public void ClickSoundPlay(){
		clickButtonAudioSource.volume = audioVolume;
		clickButtonAudioSource.clip = clickPlayButtonAudio;
		clickButtonAudioSource.Play();
	}

	public void ClickSoundGeneral(){
		clickButtonAudioSource.volume = audioVolume;
		clickButtonAudioSource.clip = clickButtonAudio;
		clickButtonAudioSource.Play();
	}

	public void ClickSoundClose(){
		clickButtonAudioSource.volume = audioVolume;
		clickButtonAudioSource.clip = clickCloseButtonAudio;
		clickButtonAudioSource.Play();
	}

	public void ClickSoundHUDClose(){
		clickButtonAudioSource.volume = audioVolume;
		clickButtonAudioSource.clip = clickCloseHUDButtonAudio;
		clickButtonAudioSource.Play();
	}

}
