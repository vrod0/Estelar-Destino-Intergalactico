using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] GameObject objActive;

    [SerializeField] GameManage gameManage = new GameManage();

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(gameObject.tag);

            if (gameObject.tag == "Collectible")
            {
                Debug.Log("Choque con el coleccionable");
                ManageCollectible();

                Destroy(gameObject);
            }
            else if (gameObject.tag == "Gun")
            {
                Destroy(gameObject);

                objActive.SetActive(true);
            }
        }
    }

    void ManageCollectible()
    {
        Debug.Log("Voy a sumar el coleccionable");

        gameManage.AddCollectible();

        gameManage.UpdateGUICollectible();

        Debug.Log("Se actualiza la GUI");


    }
}