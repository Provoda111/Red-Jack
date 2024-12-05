using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum buffCardType
{
    Rubber,
    Add,
    DestroyBuff
}

public class BuffCard : MonoBehaviour
{
    internal string buffCardName;
    internal string buffCardDescription;

    internal buffCardType buffType;

    private void Start()
    {
        switch (buffType)
        {
            case buffCardType.Rubber:
                break;
            case buffCardType.Add:
                break;
        }
    }
}
