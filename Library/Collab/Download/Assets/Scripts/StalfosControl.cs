using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalfosControl : Enemy
{
    private void Start()
    {
        move_time = 2.0f;
        duration_time = 0.5f;
        health = 2;
    }

    public override Vector2 randomMove()
    {
        int x = 0;
        int y = 0;
        int alt = 0;
        alt = Random.Range(1, 5);

        if (alt == 1)
        {
            x = -1;
            y = 0;

        }
        else if (alt == 2)
        {
            x = 0;
            y = -1;

        }
        else if (alt == 3)
        {
            x = 1;
            y = 0;

        }
        else if (alt == 4)
        {
            x = 0;
            y = 1;
        }
        return new Vector2(x, y);
    }
}
