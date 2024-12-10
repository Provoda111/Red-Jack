using UnityEngine;

public enum buffCardType
{
    Rubber,
    Add,
    Destroy
}

public class BuffCard : MonoBehaviour
{
    internal string buffCardName;
    internal string buffCardDescription;
    [SerializeField] internal Sprite buffcardImage;
    private Animator buffCardAnimator;
    [SerializeField] private ParticleSystem buffCardSpawnParticle;

    internal buffCardType buffType;

    private void Start()
    {
        buffCardAnimator = GetComponent<Animator>();
        if (System.Enum.TryParse(name, out buffCardType parsedBuffType))
        {
            buffType = parsedBuffType;
        }
        switch (buffType)
        {
            case buffCardType.Rubber:
                buffCardDescription = "Rubber";
                break;
            case buffCardType.Add:
                buffCardDescription = "This buffcard ";
                break;
            case buffCardType.Destroy:
                buffCardDescription = "Destroy";
                break;
        }
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

    public void BuffCardEffect()
    {
        buffCardSpawnParticle.Play();
    }
}
