using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvVeilsStat : MonoBehaviour
{
    public PlayerData playerData;
    public EquipVeils equipManager;

    // UI element detail panel
    public Image portraitImage;
    public TMP_Text nameText;
    public TMP_Text hpText;
    public TMP_Text strengthText;
    public TMP_Text magicText;
    public TMP_Text defPText;
    public TMP_Text defMText;

    // Prefab button persona
    public GameObject veilButton;
    public Transform buttonContainer; // tempat menyimpan daftar button


    //equip button
    public Button equipButton;
    void Start()
    {
        PopulateInventory();
    }

    void PopulateInventory()
    {
        foreach (Transform child in buttonContainer)
            Destroy(child.gameObject);

        foreach (VeilsInstance instance in playerData.ownedVeils)
        {
            GameObject btn = Instantiate(veilButton, buttonContainer);

            // Set nama di button (opsional, bisa pakai icon)
            btn.GetComponentInChildren<TMP_Text>().text = instance.template.veilName;

            // Agar button dapat mengirim instance saat diklik
            btn.GetComponent<Button>().onClick.AddListener(() =>
            {
                ShowVeilDetails(instance);
            });
        }
    }

    public void ShowVeilDetails(VeilsInstance v)
    {
        // Update portrait
        portraitImage.sprite = v.template.veilPortrait != null 
            ? v.template.veilPortrait 
            : v.template.veilIcon;

        // Update nama
        nameText.text = v.template.veilName;

        // Update stat
        hpText.text = "HP: " + v.finalHp;
        strengthText.text = "STRENGTH: " + v.finalStrength;
        magicText.text = "MAGIC: " + v.finalMagic;
        defPText.text = "P.DEF: " + v.finalDefP;
        defMText.text = "M.DEF: " + v.finalDefM;

        equipButton.onClick.RemoveAllListeners();
        equipButton.onClick.AddListener(() =>
        {
            equipManager.Equip(v);
        });
    }
}
