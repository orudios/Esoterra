using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceDisplayUI : MonoBehaviour
{
    [Header("Resource Details")]
    public GameObject prefab;
    
    [Header("UI Elements")]
    public Text atomicNumberText;
    public Text symbolText;
    public Text quantityText;

    Resource resource;
    Inventory inventory;
    int quantity = 0;
    
    
    void Start()
    {
        resource = prefab.transform.GetComponentInChildren<Resource>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Inventory>();
        
        SetImage();
        SetText();
    }

    void Update()
    {
        TryUpdateQuantity();
    }

    void SetImage()
    {
        // Make a sprite from prefab preview
        Texture2D texture = UnityEditor.AssetPreview.GetAssetPreview(prefab);
        while (texture == null) {
            System.Threading.Thread.Sleep(10);
            texture = UnityEditor.AssetPreview.GetAssetPreview(prefab);
        }
        Sprite sprite = Sprite.Create(
            texture,
            new Rect(0.0f, 0.0f, texture.width, texture.height),
            new Vector2(0.5f, 0.5f),
            100.0f
        );
        // Set the sprite as image on this object
        gameObject.GetComponent<Image>().sprite = sprite;
    }

    void SetText()
    {
        atomicNumberText.text = resource.atomicNumber.ToString();
        symbolText.text = resource.symbol;
        UpdateQuantity();
    }

    // Do update on condition
    void TryUpdateQuantity()
    {
        if (quantity != inventory.Quantity(resource.ID)) {
            UpdateQuantity();
        }
    }

    void UpdateQuantity()
    {
        quantity = inventory.Quantity(resource.ID);
        quantityText.text = quantity.ToString();

        // 0: Red
        if (quantity == 0) {
            quantityText.color = new Color32(255, 0, 0, 255);
        }
        // 1: Orange
        else if (quantity == 1) {
            quantityText.color = new Color32(255, 130, 0, 255);
        }
        // >1: Green
        else {
            quantityText.color = new Color32(0, 255, 0, 255);
        }
    }
}
