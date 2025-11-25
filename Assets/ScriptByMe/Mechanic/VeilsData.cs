using UnityEngine;

[CreateAssetMenu(fileName = "VeilsTemplate", menuName = "Scriptable Objects/VeilsTemplate")]
public class VeilsData : ScriptableObject
{
    public string veilName;

    public int baseHp;
    public int baseStrength;
    public int baseMagic;
    public int baseDefP;
    public int baseDefM;

    public Sprite veilIcon;
    public Sprite veilPortrait;
}
