using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ListedHero : MonoBehaviour
{
    public Image image;
    public TMP_Text name;
    public TMP_Text lifeData;
    public TMP_Text stats;
    public void Init(Entity entityToDisplay)
    {
        image.sprite = Resources.Load<Sprite>(entityToDisplay.GetImagePath());
        name.text = entityToDisplay.entityName;
        lifeData.text = $"Level: {entityToDisplay.level}\nHealth: {entityToDisplay.currentHealth}\nMana: {entityToDisplay.currentMana}";
        stats.text = $"Strength: {entityToDisplay.Strength()}\nDexterity: {entityToDisplay.Dexterity()}\nIntelligence: {entityToDisplay.Intelligence()}";
    }
}
