using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlotNumber : MonoBehaviour
{
    [SerializeField] private GameObject slotNumber;

    public void setNumber(Sprite p_image)
    {
        GetComponent<SpriteRenderer>().sprite = p_image;
    }

    public void setActive(bool status)
    {
        slotNumber.SetActive(status);
    }
}
