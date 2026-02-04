using UnityEngine;

public class CuttingCounter : BaseCounter
{

    [SerializeField] private CutttingRecipeSO[] cutttingRecipeSOArray;

    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {
            //There is no Kitchen Object here
            if(player.HasKitchenObject())
            {
                //Player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //Player is carrying something that can be cut
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
            }
            else
            {
                //Player is not carrying anything
            }
        }
        else
        {
            //There is a Kitchen Object here
            if(player.HasKitchenObject())
            {
                //Player is carrying something
            }
            else
            {
                //Player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
            
        }
    }

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            //There is a Kitchen Object here and it can be cut
            KitchenObjectSO outputKitchenObjectSO = getOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CutttingRecipeSO cutttingRecipeSO in cutttingRecipeSOArray)
        {
            if(cutttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }

    private KitchenObjectSO getOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (CutttingRecipeSO cutttingRecipeSO in cutttingRecipeSOArray)
        {
            if(cutttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cutttingRecipeSO.output;
            }
        }
        return null;
    }
}