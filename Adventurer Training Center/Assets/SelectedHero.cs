using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectedHero : MonoBehaviour
{
    public Image heroImage;
    public TMP_Text heroName;

    public void Init(Entity hero)
    {
        heroImage.sprite = Resources.Load<Sprite>(hero.GetImagePath());
        heroName.text = hero.entityName ;
    }
}
