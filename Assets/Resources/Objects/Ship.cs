using UnityEngine;
[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjects/Create Ship")]
public class Ship : ScriptableObject
{
    public string Name;
    public string Description; 
    public EnumShipTypes Type; // ��� �������, �� ���� ������� ������ �������. ������� ����� ����������� ������ ���������� ������ ����� ��������.
    public float MaxSpeed; // ������������ �������� ������� 0 - 12, ������������� �� �������. ��� ������������ � �������� ����������� � ������������� ��������.  
    public float MaxWeight; // ������������ ��� ������������, �����
    public int CargoSlots; // ���-��� ������ �����
}
