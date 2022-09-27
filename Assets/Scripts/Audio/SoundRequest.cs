using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class SoundRequest
    {
        public ESources Source { get; }
        public ESoundTypes Type { get; }

        public bool IsRandomizable { get; }
        public Vector3 Position { get; }

        private SoundRequest(ESources _source, ESoundTypes _type, Vector3 _pos, bool _rnd)
        {
            Source = _source;
            Type = _type;
            Position = _pos;
            IsRandomizable = _rnd;
        }
    } 
}
