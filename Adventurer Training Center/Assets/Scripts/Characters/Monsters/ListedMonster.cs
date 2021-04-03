using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ListedMonster : MonoBehaviour
{
    public Image image;
    public TMP_Text name;
    public TMP_Text lifeData;
    public TMP_Text description;
    public void Init(MonsterData monsterToDisplay)
    {
        image.sprite = Resources.Load<Sprite>(monsterToDisplay.GetImagePath());
        name.text = monsterToDisplay.monsterName;
        lifeData.text = $"Level: {monsterToDisplay.level}";
        description.text = $"Description: {monsterToDisplay.monsterDescription}";
    }
}
