using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AudioManaging;

public class GenerateAudio : MonoBehaviour
{
    [SerializeField] NotifyEntitySoundCollection m_sndRequests;

    private ESources m_src = ESources.PLAYER;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            m_sndRequests.Add(EntityAudioRequest.Request(m_src, ESoundTypes.WALK, transform));
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            m_sndRequests.Add(EntityAudioRequest.Request(m_src, ESoundTypes.ATTACK1, transform));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_sndRequests.Add(EntityAudioRequest.Request(m_src, ESoundTypes.JUMP, transform));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            m_sndRequests.Add(EntityAudioRequest.Request(m_src, ESoundTypes.CLICK, transform));
        }
    }
}
