using UnityEngine;

public class AddVeils : MonoBehaviour
{
    public PlayerData playerData;
    public VeilsData veilsToAdd;

    //public bool hasBeenPicked = false;

    public void AddNewVeils()
    {
        VeilsInstance newVeils = new VeilsInstance();
        newVeils.template = veilsToAdd;
        newVeils.level = 1;
        newVeils.exp = 0;

        playerData.ownedVeils.Add(newVeils);

        Debug.Log("Persona added: " + veilsToAdd.veilName);
    }

    private void OnTriggerEnter(Collider other)
    {
        AddNewVeils();
        Destroy(gameObject);
    }
}
