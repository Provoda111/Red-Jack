using UnityEngine;

public enum buffCardType
{
    Rubber,
    Add,
    Destroy
}

public class BuffCard : MonoBehaviour
{
    [SerializeField] internal string buffCardName;
    [SerializeField] internal string buffCardDescription;
    [SerializeField] internal Sprite buffcardImage;
    private Animator buffCardAnimator;
    [SerializeField] private ParticleSystem buffCardSpawnParticle;

    internal buffCardType buffType;
    private void Start()
    {
        buffCardAnimator = GetComponent<Animator>();
    }
    internal void Spawn(GameObject caller)
    {
        switch (buffType)
        {
            case buffCardType.Rubber:
                break;
            case buffCardType.Add:
                break;
            case buffCardType.Destroy:
                break;
        }
    }
    internal void GoToDeck()
    {
        
    }
    public void BuffCardEffect()
    {
        buffCardSpawnParticle.Play();
    }
}
