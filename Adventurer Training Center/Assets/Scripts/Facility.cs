using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facility : MonoBehaviour
{
    public List<FacilityUpgrade> CurrentUpgrades;
    [SerializeField]
    private int facilityLevel;
    private int goldGain;
    private int goldLoss;

    private PlayerHandler player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = gameObject.GetComponent<PlayerHandler>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
