using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newFactionData", menuName = "Faction")]
public class FactionData : ScriptableObject
{
    public string FactionName;
    public Material FactionColorMaterial;
    public List<FactionData> EnemyList;

    public bool CanHarm(FactionData other)
    {
        if (other == null)
        {
            return true;
        }
        return other != null && EnemyList.Contains(other);
    }
    public void ChangeFactionColor(MeshRenderer meshArg)
    {
        meshArg.material = FactionColorMaterial;
    }
}
