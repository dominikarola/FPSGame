using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoMagazine : MonoBehaviour
{
    public uint magazineCapacity = 10;
    public AmmoCounter counter;
    private uint loadedAmmo = 0;
    private uint storedAmmo = 0;
    // Start is called before the first frame update
    void Start()
    {
        loadedAmmo = 3;
        storedAmmo = 20;
        counter.SetLoadedAmmo(loadedAmmo);
        counter.SetStoredAmmo(storedAmmo);
    }

    public bool Fire()
    {
        if (loadedAmmo > 0)
        {
            loadedAmmo -= 1;
            counter.SetLoadedAmmo(loadedAmmo);
            return true;
        }
        else return false;
    }

    public void Reload()
    {
        if (loadedAmmo < magazineCapacity)
        {
            if (storedAmmo < magazineCapacity - loadedAmmo)
            {
                loadedAmmo += storedAmmo;
                storedAmmo = 0;
            }
            else
            {
                storedAmmo -= magazineCapacity - loadedAmmo;
                loadedAmmo = magazineCapacity;
            }
            counter.SetLoadedAmmo(loadedAmmo);
            counter.SetStoredAmmo(storedAmmo);
        }
    }

    public void PickAmmo(uint count)
    {
        storedAmmo += count;
        counter.SetStoredAmmo(storedAmmo);
    }
}
