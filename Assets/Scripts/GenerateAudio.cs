using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public class GenerateAudio : MonoBehaviour
{
    [SerializeField] NotifySoundCollection m_soundRequest;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            m_soundRequest.Add(SoundRequest.Request(ESources.PLAYER, ESoundTypes.ATTACK1, transform));
        }

        if (Input.GetKey(KeyCode.S))
        {
            m_soundRequest.Add(SoundRequest.Request(ESources.PLAYER, ESoundTypes.ATTACK2, transform));
        }

        if (Input.GetKey(KeyCode.D))
        {
            m_soundRequest.Add(SoundRequest.Request(ESources.PLAYER, ESoundTypes.JUMP, transform));
        }

        if (Input.GetKey(KeyCode.F))
        {
            m_soundRequest.Add(SoundRequest.Request(ESources.PLAYER, ESoundTypes.CLICK, transform));
        }
    }
}
