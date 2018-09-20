﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    int rupee_count = 0;
    int key_count = 0;
    int bomb_count = 0;

    public void AddRupees(int num_rupees)
    {
        rupee_count += num_rupees;
    }

    public void AddKeys(int num_keys)
    {
        key_count += num_keys;
    }

    public void AddBombss(int num_bombs)
    {
        bomb_count += num_bombs;
    }

    public int GetRupees()
    {
        return rupee_count;
    }

    public int GetKeys()
    {
        return key_count;
    }

    public int GetBombs()
    {
        return bomb_count;
    }
}
