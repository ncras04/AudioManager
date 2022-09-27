using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Audio;

public interface IPoolable
{
    void Reset();
    void Deactivate();

    void Initialize(AudioObjectPool pool);

}
