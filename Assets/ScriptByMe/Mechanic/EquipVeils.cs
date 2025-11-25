using UnityEngine;

public class EquipVeils : MonoBehaviour
{
    public PlayerData playerData;

    public void Equip(VeilsInstance veil)
    {
        playerData.equippedVeil = veil;
        Debug.Log("Equipped veil: " + veil.template.veilName);
    }
}
