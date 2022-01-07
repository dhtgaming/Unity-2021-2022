using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunktacjaZycia : MonoBehaviour
{
    private RectTransform pasekZycia;

    // Start is called before the first frame update
    void Start()
    {
        pasekZycia = GetComponent<RectTransform>();
        SetSize(Zycie.punktacjaZycia);
    }

    public void Damage(float damage)
    {
        if ((Zycie.punktacjaZycia -= damage) >= 0f)
        {
            Zycie.punktacjaZycia -= damage;
        }
        else
        {
            Zycie.punktacjaZycia = 0f;
        }

        SetSize(Zycie.punktacjaZycia);
    }

    public void DodajZycie(float dodajzycie)
    {   
        if ((Zycie.punktacjaZycia += dodajzycie) <= 1f)
        {
            Zycie.punktacjaZycia += dodajzycie;
        }
        else
        {
            Zycie.punktacjaZycia = 1f;
        }
       
        SetSize(Zycie.punktacjaZycia);
    }

    public void SetSize(float size)
    {
        pasekZycia.localScale = new Vector3(size, 1f);
    }

}
