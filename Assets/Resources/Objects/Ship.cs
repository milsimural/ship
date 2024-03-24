using UnityEngine;
[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjects/Create Ship")]
public class Ship : ScriptableObject
{
    public string Name;
    public string Descriptio;
    public EnumShipTypes Type;
    public float MaxSpeed;
    public float MaxWeight;
    public int CargoSlots;
}
