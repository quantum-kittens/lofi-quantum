using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    //LINK (drag and drop) the audisource here in the editor
    public AudioSource Source;


    //Link (drag and drop) the music clips here in the editor
    public AudioClip[] MusicType1;
    public AudioClip[] MusicType2;

    public TextMesh text;


    AudioClip[] ActiveMusicType;

    int current = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        if (Source==null) {
            Source = GetComponent<AudioSource>();
        }
        
        //to be sure to always have a type chosen.
        ChooseType(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChooseType(int type) {
        if (type==1) {
            ActiveMusicType = MusicType1;
        } else {
            ActiveMusicType = MusicType2;
        }
    }

    public void Randomize() {

    }

    public void Play() {

    }

    public void Pause() {

    }

    public void Skip() {
        
    }

}
