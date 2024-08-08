using UnityEngine;

/// <summary>  
/// Create material instances and apply colour to them.
/// </summary>
public class S_MaterialInstance : MonoBehaviour
{
    [Header("Material Instance")]
    [Tooltip("Select a material for instancing.")]
    [SerializeField] private Material _material;
    
    [Tooltip("Set the colour of the instantiated material.")]
    [SerializeField] private Color _color;

    void Start()
    {
        // Create a Material Instance
        _material = GetComponent<Renderer>().material;
        // Paint the selected color to the Material Instance
        _material.SetColor("_Color", _color);
    }
}
