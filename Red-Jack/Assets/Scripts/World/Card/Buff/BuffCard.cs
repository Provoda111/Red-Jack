using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] internal Image buffcardImage;

    internal buffCardType buffType;

    CardMover mover;

    private void ToString()
    {
        buffCardName = buffType.ToString();
    }
    private void Start()
    {
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
                buffCardDescription = "Add";
                break;
            case buffCardType.Destroy:
                buffCardDescription = "Destroy";
                break;
        }
        
    }
    static internal void Spawn()
    {
        
    }
}
