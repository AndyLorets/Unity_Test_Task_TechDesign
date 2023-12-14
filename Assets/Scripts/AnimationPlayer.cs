using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour, IPlayAnimation
{
    private Animation m_animation;
    private void Awake()
    {
        m_animation = GetComponent<Animation>();    
    }
    public void Play() => m_animation.Play();
}
