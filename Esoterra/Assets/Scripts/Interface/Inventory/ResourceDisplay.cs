using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceDisplay : MonoBehaviour
{
    [Header("Resource Details")]
    public int atomicNumber;
    public string symbol;
    public GameObject prefab;

    int quantity = 0;

    void Awake()
    {
        SetSourceImage();
        SetText();
    }

    void SetSourceImage()
    {
        Texture2D texture = UnityEditor.AssetPreview.GetAssetPreview(prefab);
        Sprite sprite = Sprite.Create(texture, new Rect(
            0.0f, 0.0f, texture.width, texture.height),
            new Vector2(0.5f, 0.5f), 100.0f);
        gameObject.GetComponent<Image>().sprite = sprite;
    }

    void SetText()
    {
        Text[] texts = gameObject.GetComponentsInChildren<Text>();

        texts[0].text = atomicNumber.ToString();
        texts[1].text = symbol;
    }
}
