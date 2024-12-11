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
                // Poistetaan kortti kutsujan vastapuolelta
                if (oppositeGamer.gameCards.Count > 0)
                {
                    GameObject cardToRemove = oppositeGamer.gameCards[0]; // Esimerkki: Poista ensimmäinen kortti
                    oppositeGamer.RemoveCardFromSlot(cardToRemove);
                }
                break;

            case buffCardType.Add:
                // Lisätään kortti vastapuolelle
                GameObject newCardToAdd = callerGamer.deck.DrawCard(); // Luo/palauta uusi kortti pakasta
                oppositeGamer.AddCardToSlot(newCardToAdd);
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
