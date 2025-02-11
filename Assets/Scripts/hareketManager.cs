using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class hareketManager : MonoBehaviour
{
    public GameObject kuyruk;
    List<GameObject> kuyruklar;
    Vector3 eskiKoordinat;
    GameObject eskiKuyruk;
    public GameObject sonucPaneli;

    float hiz = 100.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "duvar")
        {
            sonucPaneli.SetActive(true);
            Time.timeScale = 0.0f;
        }

        if (other.gameObject.tag == "kuyruk")
        {
            sonucPaneli.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void TekrarOyna()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("OyunSahnesi");

    }

    void Start()
    {
        sonucPaneli.SetActive(false);
        kuyruklar = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            GameObject yeniKuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
            kuyruklar.Add(yeniKuyruk);
        }

        InvokeRepeating("Hareket", 0.0f, 0.1f);
    }

    void Hareket()
    {
        eskiKoordinat = transform.position;
        transform.Translate(0, 0, hiz * Time.deltaTime);
        KuyrukTakip();
    }

    public void KuyrukArttir()
    {
        GameObject yeniKuyruk = Instantiate(kuyruk, transform.position, Quaternion.identity);
        kuyruklar.Add(yeniKuyruk);
    }

    void KuyrukTakip()
    {
        kuyruklar[0].transform.position = eskiKoordinat;
        eskiKuyruk = kuyruklar[0];
        kuyruklar.RemoveAt(0);
        kuyruklar.Add(eskiKuyruk);
    }

    public void Dondur(float aci)
    {
        transform.Rotate(0, aci, 0);
    }

    
    
}
