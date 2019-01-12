using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickables : MonoBehaviour 
{
    private CollectableItemData collectableItem;
    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public CollectableItemData CollectableItem
    {
        get { return collectableItem; }
        set
        {
            collectableItem = value;
            GetComponent<MeshRenderer>().material.color = collectableItem.ItemColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag.Equals("Ground"))
        {
            rigidbody.isKinematic = true;
        }
    }
}
