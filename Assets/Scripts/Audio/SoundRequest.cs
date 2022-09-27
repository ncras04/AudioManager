using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class SoundRequest
    {
        public Vector3 Position { get; }

        private SoundRequest(Vector3 _pos)
        {
            Position = _pos;
        }
    } 
}
