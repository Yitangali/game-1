using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDest3 : MonoBehaviour
{
    public int pivotPoint = 0;

    // UBAH JADI PUBLIC AGAR BISA DRAG & DROP
    public GameObject npcObject; 

    // Void Start tidak dibutuhkan lagi untuk mencari Tag
    // void Start() { ... } 

    void Update()
    {
        // Safety check: Kalau lupa masukin NPC, jangan jalan dulu
        if (npcObject == null) return;

        // Cek Jarak antara CUBE INI dengan NPC YANG SUDAH DIPILIH
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
            transform.position = new Vector3(-2.033676f, -2.03928f, 75.12003f);
            pivotPoint = 1;
        }
        else if (pivotPoint == 1)
        {
            // Pindah ke Titik 2
            transform.position = new Vector3(13.06f, -2.03928f, 91.54f);
            pivotPoint = 2;
        }
        else if (pivotPoint == 2)
        {
            // Pindah ke Titik 3
            transform.position = new Vector3(-2.5f, -2.03928f, 103.1f);
            pivotPoint = 3;
        }
        else if (pivotPoint == 3)
        {
            // === LOOPING ===
            // Kembali ke koordinat awal
            transform.position = new Vector3(-2.033676f, -2.03928f, 75.12003f); 
            pivotPoint = 0;
        }
    }
}