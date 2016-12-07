using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveControllers : MonoBehaviour {

    private SteamVR_TrackedObject _trackedObj;
    private SteamVR_Controller.Device _controller { get { return SteamVR_Controller.Input((int)_trackedObj.index); } }

    private EVRButtonId _grip = EVRButtonId.k_EButton_Grip;

    private HashSet<Item> _itemsIsHoveringOver = new HashSet<Item>();
    private Item _interactingItem, _closestItem;

	// Use this for initialization
	void Start () {
        _trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        // controller not initialized
        if (_controller == null)
        {
            return;
        }
        else
        {
            // grip was pressed
            if (_controller.GetPressDown(_grip))
            {
                float minDistance = float.MaxValue, distance;

                foreach (Item item in _itemsIsHoveringOver) // find the closest item to the controller
                {
                    distance = (item.transform.position - transform.position).sqrMagnitude;

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        _closestItem = item;
                    }
                }

                _interactingItem = _closestItem;
                _closestItem = null;

                if (_interactingItem)
                {
                    if (_interactingItem.IsInteracting()) // for passing on objects between hands
                    {
                        // stop interacting on the item
                        _interactingItem.EndInteraction(this);
                    }

                    // begin interacting with the other "hand"
                    _interactingItem.BeginInteraction(this);
                }
            }

            // Grip was released
            if (_controller.GetPressUp(_grip) && _interactingItem != null)
            {
                // stop interacting with the object
                _interactingItem.EndInteraction(this);
            }
        }
	}

    private void OnTriggerEnter(Collider collider)
    {
        Item collidedItem = collider.GetComponent<Item>();
        Debug.Log("ENTER: " + collider.gameObject.name);

        // when we collided with an item that's interactable
        if (collidedItem)
        {
            _itemsIsHoveringOver.Add(collidedItem);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Item collidedItem = collider.GetComponent<Item>();

        Debug.Log("EXIT :" + collider.gameObject.name);


        // when we collided with an item that's interactable
        if (collidedItem)
        {
            _itemsIsHoveringOver.Remove(collidedItem);
        }
    }
}
