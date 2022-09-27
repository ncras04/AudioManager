using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManaging;

public class GenerateAudio : MonoBehaviour
{
    [SerializeField] NotifySoundCollection m_soundRequest;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            m_soundRequest.Add(AudioRequest<ESources,ESoundTypes>.Request(ESources.PLAYER, ESoundTypes.WALK, transform));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            m_soundRequest.Add(AudioRequest<ESources, ESoundTypes>.Request(ESources.PLAYER, ESoundTypes.ATTACK1, transform));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_soundRequest.Add(AudioRequest<ESources, ESoundTypes>.Request(ESources.PLAYER, ESoundTypes.JUMP, transform));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            m_soundRequest.Add(AudioRequest<ESources, ESoundTypes>.Request(ESources.PLAYER, ESoundTypes.CLICK, transform));
        }
    }
}
