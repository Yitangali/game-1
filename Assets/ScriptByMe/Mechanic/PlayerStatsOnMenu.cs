using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatsOnMenu : MonoBehaviour
{
    public PlayerData playerData;
    //public Image iconImage;
    //public Text levelText;
    public TMP_Text hpText;
    public TMP_Text strengthText;
    public TMP_Text magicText;
    public TMP_Text defPText;
    public TMP_Text defMText;

    void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (playerData.equippedVeil == null)
        {
            //iconImage.sprite = null;
            //levelText.text = "No Persona";
            //statsText.text = "";
            hpText.text = "HP: NULL";
            strengthText.text = "STRENGTH: NULL"; 
            magicText.text = "MAGIC: NULL"; 
            defPText.text = "P.DEF: NULL"; 
            defMText.text = "M.DEF: NULL"; 
            return;
        }

        VeilsInstance v = playerData.equippedVeil;

        //iconImage.sprite = p.Icon;
        //levelText.text = "Level: " + p.level;

        hpText.text = " " + v.finalHp;
        strengthText.text = " " + v.finalStrength;
        magicText.text = " " + v.finalMagic;
        defPText.text = " " + v.finalDefP;
        defMText.text = " " + v.finalDefM;

    }
}
