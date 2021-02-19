using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomUpgrade : MonoBehaviour
{
    public bool openUI;
    public List<FacilityUpgrade> RoomUpgrades;
    public List<FacilityUpgrade> currRoomUpgrades;
    [SerializeField]
    private GameObject playerHandler;
    public List<GameObject> UpgradeButtons;
    [SerializeField]
    private Transform upgradeContainer;
    private Transform upgradeTemplate;

    public int attributeToAffect;
    
    private void Awake()
    {
        openUI = false;
        gameObject.GetComponent<Button>().onClick.AddListener(() => {OpenPanel(); });
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OpenPanel()
    {
        openUI = !openUI;
        gameObject.SetActive(openUI);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StatusOfRoom()
    {

    }
    public void TryBuyUpgrade(FacilityUpgrade upgradeToBuy)
    {

        if (playerHandler.GetComponent<PlayerHandler>().BuyFacilityRoomCreation(upgradeToBuy))
        {
            RoomUpgrades.Remove(upgradeToBuy);
            currRoomUpgrades.Add(upgradeToBuy);
        }
    }
    private void CreateUpgradeButtons(FacilityUpgrade upgrade, Sprite upgradeSprite, string upgradeDescription, int upgradeCost, string upgradeName, int posIndex)
    {
        Transform upgradeTransform = Instantiate(upgradeTemplate, upgradeContainer);
        UpgradeButtons.Add(upgradeTransform.gameObject);
        RectTransform upgradeRectTransform = upgradeTransform.GetComponent<RectTransform>();

        float upgradeItemHeight = 120f;
        upgradeRectTransform.anchoredPosition = new Vector2(0, -upgradeItemHeight * posIndex);

        upgradeTransform.Find("UpgradeName").GetComponent<Text>().text = upgradeName;
        upgradeTransform.Find("UpgradeCost").GetComponent<Text>().text = "Cost: " + upgradeCost;
        upgradeTransform.Find("UpgradeDescription").GetComponent<Text>().text = upgradeDescription;

        upgradeTransform.Find("UpgradeImage").GetComponent<Image>().sprite = upgradeSprite;

        upgradeTransform.GetComponent<Button>().onClick.AddListener(() => { TryBuyUpgrade(upgrade); });
    }
}
