using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class AmmoCounter : MonoBehaviour
{
    private uint loadedAmmo;
    private uint storedAmmo;
    private Text m_Text;

    // Start is called before the first frame update
    private void Start()
    {
        m_Text = GetComponent<Text>();
    }

    public void SetLoadedAmmo(uint count)
    {
        loadedAmmo = count;
        UpdateText();
    }

    public void SetStoredAmmo(uint count)
    {
        storedAmmo = count;
        UpdateText();
    }

    public void UpdateText()
    {
        if (loadedAmmo == 0 && storedAmmo > 0)
        {
            m_Text.color = new Color(1.0f, 0.0f, 0.0f);
            m_Text.text = loadedAmmo.ToString() + "/" + storedAmmo.ToString() + " Press \"R\" to reload!";
        }
        else if (loadedAmmo == 0 && storedAmmo == 0)
        {
            m_Text.color = new Color(0.8f, 0.0f, 0.0f);
            m_Text.text = loadedAmmo.ToString() + "/" + storedAmmo.ToString() + " No ammo!";
        }
        else if (loadedAmmo + storedAmmo < 6)
        {
            m_Text.color = new Color(0.9f, 0.5f, 0.0f);
            m_Text.text = loadedAmmo.ToString() + "/" + storedAmmo.ToString();
        }
        else
        {
            m_Text.color = new Color(0.0f, 0.9f, 0.0f);
            m_Text.text = loadedAmmo.ToString() + "/" + storedAmmo.ToString();
        }
    }
}
