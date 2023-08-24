using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI contadorColeccionable;

    int collectedCollectibles = 0;

    public void AddCollectible()
    {
        collectedCollectibles++;
    }

    public void UpdateGUICollectible()
    {
        contadorColeccionable.text = "0" + collectedCollectibles;
        Debug.Log("Actualize el contador en pantalla menor a 0!");

    }

    public int GetCollectibles()
    {
        return collectedCollectibles;
    }
}