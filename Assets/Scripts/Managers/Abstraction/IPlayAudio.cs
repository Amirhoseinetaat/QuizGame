using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers.Abstraction
{
    public interface IPlayAudio
    {
        IEnumerator PlayAudioClip(string URL);
        void StopPlayAudioClip();
    }
}