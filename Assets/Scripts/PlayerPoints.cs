using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    [SerializeField] EtherBar etherBar;
    [SerializeField] ShadowEtherBar shadowEtherBar;

    public int etherCount;
    public int shadowEtherCount;

    // Start is called before the first frame update
    void Start()
    {
        etherCount = shadowEtherCount = 0;
        etherBar.SetEther(etherCount);
        shadowEtherBar.SetShadowEther(shadowEtherCount);
    }
}
