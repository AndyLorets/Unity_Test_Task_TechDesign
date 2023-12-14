using UnityEngine;

public class ClickAnimationPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] m_PlayAnimationSource;
    private IPlayAnimation[] m_PlayAnimation;

    private void Awake()
    {
        m_PlayAnimation = new IPlayAnimation[m_PlayAnimationSource.Length]; 
        for (int i = 0; i < m_PlayAnimationSource.Length; i++)
            m_PlayAnimation[i] = m_PlayAnimationSource[i].GetComponent<IPlayAnimation>();
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < m_PlayAnimationSource.Length; i++)
            m_PlayAnimation[i].Play();

        gameObject.SetActive(false);    
    }
}
