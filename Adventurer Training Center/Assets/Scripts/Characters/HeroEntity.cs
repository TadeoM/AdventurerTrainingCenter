using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroClass
{
    Ranger,
    Warrior,
    Mage
}

public struct Hero
{
    public int level;
    public string name;
    public HeroClass heroClass;
    public Hero(HeroEntity entity)
    {
        level = entity.level;
        name = entity.name;
        heroClass = entity.heroClass;
    }
}
public class HeroEntity : Entity
{
    public HeroClass heroClass;

    public override Entity Init()
    {
        switch (heroClass)
        {
            case HeroClass.Ranger:
                strength = 1;
                dexterity = 3;
                intelligence = 2;
                break;
            case HeroClass.Warrior:
                strength = 3;
                dexterity = 2;
                intelligence = 1;
                break;
            case HeroClass.Mage:
                strength = 1;
                dexterity = 2;
                intelligence = 3;
                break;
            default:
                break;
        }
        return base.Init();
    }

    public Entity Init(Hero hero)
    {
        level = hero.level;
        heroClass = hero.heroClass;
        entityName = hero.name;
        return Init();
    }
    public Entity Init(HeroEntity entity)
    {
        heroClass = entity.heroClass;
        return base.Init(entity);
    }

    public override string GetImagePath()
    {
        switch (heroClass)
        {
            case HeroClass.Ranger:
                return "frames/SpriteSheets/FlowerElf";
            case HeroClass.Warrior:
                return "frames/SpriteSheets/OrangeKnight";
            case HeroClass.Mage:
                return "frames/SpriteSheets/Wizard";
            default:
                return "";
        }
    }
}
