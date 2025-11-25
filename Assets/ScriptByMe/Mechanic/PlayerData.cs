using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public int baseHp;
    public int baseStrength;
    public int baseMagic;
    public int baseDefP;
    public int baseDefM;

    public List<VeilsInstance> ownedVeils = new List<VeilsInstance>();

    public VeilsInstance equippedVeil;

    public int finalHp => baseHp + (equippedVeil != null ? equippedVeil.finalHp : 0);
    public int finalStrength => baseStrength + (equippedVeil != null ? equippedVeil.finalStrength : 0);
    public int finalMagic => baseMagic + (equippedVeil != null ? equippedVeil.finalMagic : 0);
    public int finalDefP => baseDefP + (equippedVeil != null ? equippedVeil.finalDefP : 0);
    public int finalDefM => baseDefM + (equippedVeil != null ? equippedVeil.finalDefM : 0);
    
}
