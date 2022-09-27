using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioManaging
{
    public class EntityAudioRequest : AudioRequest<ESoundTypes>
    {
        public ESources Source { get; }
        public bool IsRandomizable { get; }
        public Transform Parent { get; }
        public Vector3 Position { get; }

        public static EntityAudioRequest Request(ESources _source, ESoundTypes _type, Transform _parent)
        {
            return new EntityAudioRequest(_source, _type, _parent, _parent.position, false);
        }
        private EntityAudioRequest(ESources _source, ESoundTypes _type, Transform _parent, Vector3 _pos, bool _rnd)
                : base(_type)
        {
            Source = _source;
            Parent = _parent;
            Position = _pos;
            IsRandomizable = _rnd;
        }
    }
}
