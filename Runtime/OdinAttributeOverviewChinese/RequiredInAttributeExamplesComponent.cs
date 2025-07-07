// RequiredInAttributeExamplesComponent.cs
using Sirenix.OdinInspector;
using UnityEngine;

public class RequiredInAttributeExamplesComponent : MonoBehaviour
{
    [RequiredIn(PrefabKind.InstanceInScene, ErrorMessage = "Error messages can be customized. Odin expressions is supported.")]
    public string InstanceInScene = "Instances of prefabs in scenes";
    
    [RequiredIn(PrefabKind.InstanceInPrefab)]
    public string InstanceInPrefab = "Instances of prefabs nested inside other prefabs";
    
    [RequiredIn(PrefabKind.Regular)]
    public string Regular = "Regular prefab assets";
    
    [RequiredIn(PrefabKind.Variant)]
    public string Variant = "Prefab variant assets";
    
    [RequiredIn(PrefabKind.NonPrefabInstance)]
    public string NonPrefabInstance = "Non-prefab component or gameobject instances in scenes";
    
    [RequiredIn(PrefabKind.PrefabInstance)]
    public string PrefabInstance = "Instances of regular prefabs, and prefab variants in scenes or nested in other prefabs";
    
    [RequiredIn(PrefabKind.PrefabAsset)]
    public string PrefabAsset = "Prefab assets and prefab variant assets";
    
    [RequiredIn(PrefabKind.PrefabInstanceAndNonPrefabInstance)]
    public string PrefabInstanceAndNonPrefabInstance = "Prefab Instances, as well as non-prefab instances";
}