using Managers.Abstraction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Managers
{
    public class AudioManager : MonoBehaviour, IPlayAudio
    { 
        private AudioSource audioSource;
        private AudioClip myClip;
        public  void Initialization()
        {
            audioSource= gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
        }
        public IEnumerator PlayAudioClip(string URL)
        { 
            WWW www = new WWW(URL);
            yield return www; 
            audioSource.clip = www.GetAudioClip(false, false);
            audioSource.Play();
        }
        public void StopPlayAudioClip()
        { 
            audioSource.Stop();
        }
    }
}
