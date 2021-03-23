using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingField : MonoBehaviour
{

    public int cost;
    public int level;

    public int successModifier;
    public int failureModifier;


    private float result;
    public List<Entity> currTraineesInFacility;
    public int amountSucceeded;

    [SerializeField]
    private float chanceToSucceed;
    bool success;
    private float chanceToFail;
    public enum TypeOfTraining 
    {
        Dexterity,
        Strength,
        Intelligence
    }
    private TypeOfTraining training;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerformTraining()
    {
        CalculateResult(training);

    }
    public void Upgrade()
    {
        int upgradeCost = cost * 5;
        if(PlayerHandler.Instance.CheckGoldForSpend(upgradeCost))
        {
            level += 1;
        }
    }
    void CalculateResult(TypeOfTraining training)
    {
       
        chanceToSucceed += (float)(level * 0.05);
        foreach (Entity trainee in currTraineesInFacility)
        {
            if (Random.Range(0,100)<=chanceToSucceed)
            {
                Debug.Log("Performed Training Success");
                amountSucceeded += 1;
                switch (training)
                {
                    case TypeOfTraining.Dexterity:
                        //int stat = upgradeModifier+1;
                        PlayerHandler.Instance.dexterityMod += successModifier;
                        break;
                    case TypeOfTraining.Strength:
                        PlayerHandler.Instance.strengthMod += successModifier;
                        break;
                    case TypeOfTraining.Intelligence:
                        PlayerHandler.Instance.intelligenceMod += successModifier;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if(Random.Range(0,100)>=chanceToFail)
                {
                    Debug.Log("Performed Training Fail");
                    switch (training)
                    {
                        case TypeOfTraining.Dexterity:
                            PlayerHandler.Instance.dexterityMod -= failureModifier;
                            break;
                        case TypeOfTraining.Strength:
                            PlayerHandler.Instance.strengthMod -= failureModifier;
                            break;
                        case TypeOfTraining.Intelligence:
                            PlayerHandler.Instance.intelligenceMod -= failureModifier;
                            break;
                        default:
                            break;
                    }
                }
              
            }
        }
        
    }
}
