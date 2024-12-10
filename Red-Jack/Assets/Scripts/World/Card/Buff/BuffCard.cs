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
    [SerializeField] internal Sprite buffcardImage;

    internal buffCardType buffType;

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
                buffCardDescription = "This buffcard ";
                break;
            case buffCardType.Destroy:
                buffCardDescription = "Destroy";
                break;
        }
        
    }
    internal void Spawn()
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
}
