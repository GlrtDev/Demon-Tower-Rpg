using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public GameObject inventory;

    public void Start()
    {
        inventory.SetActive(true);
        inventory.SetActive(false);
    }

    public void OpenInventory()
    {
        inventory.SetActive(!inventory.activeSelf);
        if(inventory.activeSelf)
        inventory.GetComponent<WeaponClientUI>().Refresh();
    }
}
