using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public GameObject upgradePanel;
    public List<FacilityUpgrade> UpgradesAvailable;

   
    [SerializeField]
    private Transform upgradeContainer;
    private Transform upgradeTemplate;

    [SerializeField]
    private GameObject playerHandler;

    private bool centerUpgradesPanelActive;
    private void Awake()
    {
        centerUpgradesPanelActive = false;
        upgradeContainer = transform.Find("Container");
        upgradeTemplate = upgradeContainer.Find("UpgradeTemplate");
        upgradeTemplate.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void Start()
    {
        for (int i = 0; i < UpgradesAvailable.Count; i++)
        {
            CreateUpgradeButtons(UpgradesAvailable[i],UpgradesAvailable[i].UpgradeThumbnail, UpgradesAvailable[i].UpgradeDescription, UpgradesAvailable[i].UpgradeCost, UpgradesAvailable[i].UpgradeName, i);
            Debug.Log("What");
        }
        
    }
    
    private void CreateUpgradeButtons(FacilityUpgrade upgrade, Sprite upgradeSprite, string upgradeDescription, int upgradeCost, string upgradeName, int posIndex)
    {
        Transform upgradeTransform = Instantiate(upgradeTemplate, upgradeContainer);
        RectTransform upgradeRectTransform = upgradeTransform.GetComponent<RectTransform>();

        float upgradeItemHeight = 120f;
        upgradeRectTransform.anchoredPosition = new Vector2(0, -upgradeItemHeight * posIndex);

        upgradeTransform.Find("UpgradeName").GetComponent<Text>().text = upgradeName;
        upgradeTransform.Find("UpgradeCost").GetComponent<Text>().text ="Cost: "+ upgradeCost;
        upgradeTransform.Find("UpgradeDescription").GetComponent<Text>().text = upgradeDescription;

        upgradeTransform.Find("UpgradeImage").GetComponent<Image>().sprite = upgradeSprite;

        upgradeTransform.GetComponent<Button>().onClick.AddListener(() => { TryBuyUpgrade(upgrade); });
    }
    public void OpenPanel()
    {
        centerUpgradesPanelActive = !centerUpgradesPanelActive;
        gameObject.SetActive(centerUpgradesPanelActive);
    }

    public void TryBuyUpgrade(FacilityUpgrade upgradeToBuy)
    {
        playerHandler.GetComponent<PlayerHandler>().BuyFacilityUpgrade(upgradeToBuy);
    }
  
}
