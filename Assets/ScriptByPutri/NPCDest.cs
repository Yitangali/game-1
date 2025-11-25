using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDest : MonoBehaviour
{
    public int pivotPoint = 0;
    GameObject npcObject; 

    void Start()
    {
        npcObject = GameObject.FindGameObjectWithTag("NPC");
        if (npcObject == null) Debug.LogError("Tag NPC belum disetting!");
    }

    void Update()
    {
        if (npcObject == null) return;

        // Cek Jarak
        float jarak = Vector3.Distance(transform.position, npcObject.transform.position);

        if (jarak < 2.5f) 
        {
            PindahPosisi();
        }
    }

    void PindahPosisi()
    {
        if (pivotPoint == 0)
        {
            // Pindah ke Titik 1
            transform.position = new Vector3(203.01f, 0.89f, -141.8f);
            pivotPoint = 1;
        }
        else if (pivotPoint == 1)
        {
            // Pindah ke Titik 2
            transform.position = new Vector3(188.9f, 0.89f, -132.7f);
            pivotPoint = 2;
        }
        else if (pivotPoint == 2)
        {
            // Pindah ke Titik 3
            transform.position = new Vector3(188.9f, 0.89f, -151.19f);
            pivotPoint = 3;
        }
        else if (pivotPoint == 3)
        {
            // === BAGIAN LOOPING (KEMBALI KE POSISI AWAL) ===
            
            // PERBAIKAN: Saya ubah 152f menjadi -152f (Negatif)
            // Sesuaikan angka -152f ini dengan posisi start NPC Anda yang sebenarnya.
            transform.position = new Vector3(203.01f, 0.89f, -152f); 
            
            // Reset ke 0 agar siklus berulang
            pivotPoint = 0;
        }
    }
}