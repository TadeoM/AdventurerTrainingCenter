using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingField : MonoBehaviour
{

    public int cost;
    public int level;

    public int upgradeModifier;
    public int failureModifier;


    private float result;
    public List<Entity> currTraineesInFacility;
    public int amountSucceeded;

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
    void CalculateResult(TypeOfTraining training)
    {
       
        chanceToSucceed += (float)(level * 0.05);
        foreach (Entity trainee in currTraineesInFacility)
        {
            if(Random.Range(0,100)<=chanceToSucceed)
            {
                amountSucceeded += 1;
                switch (training)
                {
                    case TypeOfTraining.Dexterity:
                        //int stat = upgradeModifier+1;
                        trainee.SetDexterity(upgradeModifier);
                        break;
                    case TypeOfTraining.Strength:
                        trainee.SetStrength(upgradeModifier);
                        break;
                    case TypeOfTraining.Intelligence:
                        trainee.SetIntelligence(upgradeModifier);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if(Random.Range(0,100)>=chanceToFail)
                {
                    switch (training)
                    {
                        case TypeOfTraining.Dexterity:
                            trainee.SetDexterity(failureModifier);
                            break;
                        case TypeOfTraining.Strength:
                            trainee.SetStrength(failureModifier);
                            break;
                        case TypeOfTraining.Intelligence:
                            trainee.SetIntelligence(failureModifier);
                            break;
                        default:
                            break;
                    }
                }
              
            }
        }
        
    }
}
