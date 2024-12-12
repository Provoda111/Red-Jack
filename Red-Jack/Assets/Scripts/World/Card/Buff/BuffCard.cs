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
        Gamer callerGamer = caller.GetComponent<Gamer>();

        Gamer oppositeGamer = caller.name == "Player"
            ? GameObject.Find("Enemy").GetComponent<Gamer>()
            : GameObject.Find("Player").GetComponent<Gamer>();
        switch (buffType)
        {
            case buffCardType.Rubber:
                if (oppositeGamer.gameCards.Count > 0)
                {
                    GameObject cardToRemove = oppositeGamer.gameCards[0]; 
                    oppositeGamer.RemoveCardFromSlot(cardToRemove);
                }
                break;
            case buffCardType.Add:

                //GameObject newCardToAdd = callerGamer.deck.GiveCardToPlayer(); 
                //oppositeGamer.AddCardToSlot(newCardToAdd);
                break;

            case buffCardType.Destroy:
              
                if (oppositeGamer.gameCards.Count > 0)
                {
                    GameObject cardToDestroy = oppositeGamer.gameCards[0]; 
                    Destroy(cardToDestroy); 
                    oppositeGamer.RemoveCardFromSlot(cardToDestroy); 
                }
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
