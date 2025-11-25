using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDest2 : MonoBehaviour
{
    public int pivotPoint = 0;

    // SAYA UBAH JADI PUBLIC AGAR BISA DRAG & DROP DI INSPECTOR
    // Tujuannya agar Cube ini tidak salah mengenali NPC lain.
    public GameObject npcObject; 

    // Void Start dihapus karena kita tidak pakai pencarian Tag lagi
    // void Start() { ... }

    void Update()
    {
        // Safety check: Kalau lupa memasukkan NPC di Inspector, script diam dulu
        if (npcObject == null) return;

        // Cek Jarak antara CUBE INI dengan NPC 2
        float jarak = Vector3.Distance(transform.position, npcObject.transform.position);

        // Jika jarak kurang dari 2.5 meter, pindah titik
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
            transform.position = new Vector3(3.083817f, -1.54928f, 35.98003f);
            pivotPoint = 1;
        }
        else if (pivotPoint == 1)
        {
            // Pindah ke Titik 2
            transform.position = new Vector3(-13.52f, -1.54928f, 34.37f);
            pivotPoint = 2;
        }
        else if (pivotPoint == 2)
        {
            // Pindah ke Titik 3
            transform.position = new Vector3(-13.52f, -1.54928f, 16.28f);
            pivotPoint = 3;
        }
        else if (pivotPoint == 3)
        {
            // === LOOPING (KEMBALI KE POSISI AWAL) ===
            transform.position = new Vector3(3.083817f, -1.54928f, 35.98003f); 
            
            // Reset ke 0 agar siklus berulang
            pivotPoint = 0;
        }
    }
}