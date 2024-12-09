using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageDelivered = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

   void OnCollisionEnter2D(Collision2D other)
    {
Debug.Log("Watch Out!");
    }

    void OnTriggerEnter2D(Collider2D other)
{
if(other.tag == "Package" && !hasPackage)
{
    spriteRenderer.color = hasPackageColor;
    Debug.Log("Package picked up");
    hasPackage = true;
    Destroy(other.gameObject, destroyDelay);
}
if(other.tag == "Customer" && hasPackage)
{
    Debug.Log("Delivered Package");
    hasPackage = false;
    spriteRenderer.color = noPackageColor;
    
}else
{
    if(other.tag == "Customer" && !hasPackage)
    {
    Debug.Log("Go pick up the package!");
    spriteRenderer.color = noPackageDelivered;
    }
}
}

}
