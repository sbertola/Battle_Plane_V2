using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ReadyButton : MonoBehaviour
{
    [SerializeField] GameObject[] playerUnits;

    public void SpawnUnits()
    {
        GameObject[] units = GameObject.FindGameObjectsWithTag("PlayerM");
        int unitNum = 0;

        foreach (GameObject unit in units)
        {
            Vector3 tempPos = unit.transform.position;

            GameObject friendly = (GameObject)Instantiate(playerUnits[0]);

            friendly.transform.position = tempPos;
            friendly.GetComponent<Player>().unitNum = unitNum;

            Destroy(unit);
            unitNum++;
        }
    }
}
