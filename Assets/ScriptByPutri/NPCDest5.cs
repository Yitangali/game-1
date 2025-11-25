using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDest5 : MonoBehaviour
{
    public int pivotPoint = 0;

    // Ganti jadi PUBLIC biar aman (Drag & Drop NPC 5 kesini)
    public GameObject npcObject; 

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
        // LOGIKA YANG BENAR:
        // Kalau sampai di Titik 0, suruh pindah ke Kordinat Titik 1
        // Kalau sampai di Titik 1, suruh pindah ke Kordinat Titik 2
        // dst.

        if (pivotPoint == 0)
        {
            // Sudah sampai awal, sekarang pindah ke Titik 2 (-226.31f)
            transform.position = new Vector3(-125.75f, -4.14f, -226.31f);
            pivotPoint = 1;
        }
        else if (pivotPoint == 1)
        {
            // Sudah sampai Titik 2, sekarang pindah ke Titik 3 (-225.58f)
            transform.position = new Vector3(-147.55f, -4.14f, -225.58f);
            pivotPoint = 2;
        }
        else if (pivotPoint == 2)
        {
            // Sudah sampai Titik 3, KEMBALI KE AWAL (-210.87f)
            transform.position = new Vector3(-125.75f, -4.14f, -210.87f);
            
            // Reset pivot ke 0
            pivotPoint = 0;
        }
    }
}