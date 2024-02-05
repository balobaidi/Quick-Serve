using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject {

    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float fryingTimerMax;
}
