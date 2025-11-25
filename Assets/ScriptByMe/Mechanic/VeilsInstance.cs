using UnityEngine;

[System.Serializable]
//[CreateAssetMenu(fileName = "VeilsInstance", menuName = "Scriptable Objects/VeilsInstance")]

public class VeilsInstance
{
    public VeilsData template;
    public int level = 1;
    public int exp = 0;

    public int finalHp => template.baseHp + (10 * level);
    public int finalStrength => template.baseStrength + (2 * level);
    public int finalMagic => template.baseMagic + (2 * level);
    public int finalDefP => template.baseDefP + (2 * level);
    public int finalDefM => template.baseDefM + (2 *level);

    public Sprite icon => template.veilIcon;
    public Sprite portrait => template.veilPortrait;
}
