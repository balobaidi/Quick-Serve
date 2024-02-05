using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent {

    public static event EventHandler OnObjectPlacedHere;

    public static void ResetStaticData() {
        OnObjectPlacedHere = null;
    }

    [SerializeField] private Transform CounterTopPoint;

    private KitchenObject kitchenObject;

    public virtual void Interact(Player player) {

        //This method should never be called
        Debug.LogError("BaseCounter.Interact();");
    }

    public virtual void InteractAlternate(Player player) {

        //This method should never be called
        //Debug.LogError("BaseCounter.Interact();");
    }

    public Transform GetKitchenObjectFollowTransform() {
        return CounterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;

        if (kitchenObject != null) {
            OnObjectPlacedHere?.Invoke(this, EventArgs.Empty);
        }
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}
