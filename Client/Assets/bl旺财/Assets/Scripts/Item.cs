using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Mushroom,
    DogHead,
}

public class Item : MonoBehaviour
{
    public ItemType itemType;
    void Start()
    {
        
    }

    public void OnItemGot(Player player)
    {
        Destroy(gameObject);

        switch(itemType)
        {
            case ItemType.Mushroom:
                player.EatMushroom();
                break;
            case ItemType.DogHead:
                GameMode.Instance.FinishGame();

                break;
        }
    }
}
