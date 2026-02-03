using NUnit.Framework;
using UnityEngine;
using System;

public class ContainerCounter : BaseCounter, IKitchenObjectParent
{

    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            // player is not carrying anything
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
            
    }

}
