using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AudioManaging
{
    [CreateAssetMenu(fileName = "NotifySoundCollection", menuName = "Audio/New NotifySound", order = 0)]
    public class NotifySoundCollection : NotifyCollection<AudioRequest<ESources,ESoundTypes>>
    {

    } 
}
