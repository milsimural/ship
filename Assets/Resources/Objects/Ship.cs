using UnityEngine;
[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjects/Create Ship")]
public class Ship : ScriptableObject
{
    public string Name;
    public string Description; 
    public EnumShipTypes Type; // Тип корабля, от него зависит бонусы корабля. Капитан может прокачивать навыки управления каждым типом кораблей.
    public float MaxSpeed; // Максимальная скорость корабля 0 - 12, переключается по еденице. Все модификаторы к скорости добавляются к максимальному значению.  
    public float MaxWeight; // Максимальный вес оборудования, груза
    public int CargoSlots; // Кол-вол слотов трюма
}
