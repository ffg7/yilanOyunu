using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elma : MonoBehaviour
{
    public TMPro.TextMeshProUGUI puanText;
    int puan=0;

    hareketManager kuyrukOlustur;

    private void Start()
    {
        kuyrukOlustur = GameObject.Find("bas").GetComponent<hareketManager>();
            
    }


    // z 20,-20,x 29 -29
    private void OnTriggerEnter(Collider carpisma)
    {
        if (carpisma.gameObject.name == "bas")
        {
            puan += 10;
            puanText.text = "SKOR " + puan;
            KoordinatDegistir();
            kuyrukOlustur.KuyrukArttir();
        }
        if (carpisma.gameObject.tag == "kuyruk")
        {
            
            KoordinatDegistir();
        }
    }

    void KoordinatDegistir()
    {
        float x = Random.Range(-29, 29);
        float z = Random.Range(-20, 20);

        transform.position = new Vector3(x, 0, z);
    }

}
