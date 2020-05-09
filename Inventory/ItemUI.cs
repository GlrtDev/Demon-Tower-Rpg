using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public class ItemUiEvent : UnityEvent<ItemUI> { }

public class ItemUI : MonoBehaviour
{
    public AbstractWeaponProduct weapon;
    public Hashtable stats;
    public ItemUiEvent onClicked;
    public Image IconImage;
    void Start()
    {
        
    }

    public virtual void Display(AbstractWeaponProduct weaponPointer, Hashtable stats)
    {
        weapon = weaponPointer;
        this.stats = stats;
        StartCoroutine("LoadIconImage");
    }

    public virtual void Click()
    {
        onClicked.Invoke(this);
        Debug.Log("Clicked");
    }

    IEnumerator LoadIconImage()
    {
        ResourceRequest resourceRequest = Resources.LoadAsync<Sprite>((string)stats["SpritePath"]);
        while (!resourceRequest.isDone)
        {
            yield return 0;
        }
        IconImage.sprite = (Sprite)resourceRequest.asset;
        Debug.Log("loaded");
    }
}
