using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public GameObject[] prev;
    public GameObject[] next;

    public void setActiveNext()
    {
        if (prev != null)
        {
            for (int i = 0; i < next.Length; i++)
            {
                prev[i].SetActive(false);

            }

        }

        for (int i = 0; i < next.Length; i++)
        {
            next[i].SetActive(true);

        }
    }

    public void setActivePrev()
    {
        if (prev != null)
        {
            for (int i = 0; i < next.Length; i++)
            {
                prev[i].SetActive(true);

            }

        }
        for (int i = 0; i < next.Length; i++)
        {
            next[i].SetActive(false);

        }
    }

}
