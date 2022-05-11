using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //LINK (drag and drop) the audisource here in the editor
    public AudioSource Source;


    //Link (drag and drop) the music clips here in the editor The music for type 1 in the one array and the other in the other array
    // Type 1 = Calm, Type 2 = Chill
    public AudioClip[] MusicType1;
    public AudioClip[] MusicType2;



    AudioClip[] ActiveMusicType;

    int current = 0;
    bool hasStarted = false;
    bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Source==null) {
            Source = GetComponent<AudioSource>();
        }
        
        //For autostart you could have it here to be sure to always have a type chosen.
        //ChooseType(1);
        ChooseType(1);
	
    }

    // Update is called once per frame
    void Update()
    {
        //play the next song when song is finished
        if (hasStarted && ! Source.isPlaying && !isPaused) {
            Debug.Log("Finished play next");
            PlayNext();
        }
    }


    public void ChooseType(int type) {
        Debug.Log("Choose types");
        if (type==1) {
            ActiveMusicType = MusicType1;
        } else {
            ActiveMusicType = MusicType2;
        }
        Randomize();
        current = 0;
        Source.clip = ActiveMusicType[current];
        hasStarted = true;
        Play();
    }

    public void Randomize() {
        Debug.Log("Randomize");
        int rnd = 0;
        for (int i = 0; i < ActiveMusicType.Length; i++) {
            rnd = Random.Range(0, ActiveMusicType.Length);
            AudioClip tmp = ActiveMusicType[i];
            ActiveMusicType[i] = ActiveMusicType[rnd];
            ActiveMusicType[rnd] = tmp;
        }
    }

    public void Play() {

        if (isPaused) {
            Debug.Log("play unpause");
            Source.UnPause();
            isPaused = false;
        } else {
            Debug.Log("Play");
            Source.Play();
        }
    }
    public void Pause() {
        Debug.Log("pause pressed.");
        if (isPaused) {
            Debug.Log("unpause");
            Source.UnPause();
            isPaused = false;
        } else {
            Source.Pause();
            isPaused = true;
            Debug.Log("Pause");
        }
    }

    public void PlayNext() {
        Debug.Log("Play next");
        current++;
        current = current % ActiveMusicType.Length;
        Source.clip = ActiveMusicType[current];
        Source.Play();
    }

}
