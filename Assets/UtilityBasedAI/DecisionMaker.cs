using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public class Decision
    {
        public QualifierElement QualifierRef;
        public ContextBase Context;
    }

    public class Decision<T> : Decision
    {
        public T Target;
    }

    public abstract class DecisionMaker : ScriptableObject
    {
        public string Name;
        public AIAgent Requester;

        public List<QualifierElement> Qualifiers;
        public List<Decision> PossibleDecisions = null;

        //foreach possible decision pair it with target given by context
        //this is bad solution, because to create new qualifier we need to upgrade this method
        public virtual void MakeDecisionsList(ContextBase context)
        {

        }

        public Decision Select(ILogHandler logHandler = null)
        {
            float maxScore = float.MinValue;
            Decision bestDecision = null;

            for (int i = 0; i < PossibleDecisions.Count; ++i)
            {
                logHandler?.WriteText($"\tDCE: {PossibleDecisions[i].QualifierRef.Name}");

                float score = PossibleDecisions[i].QualifierRef.Score(PossibleDecisions[i].Context, maxScore, logHandler);
                if (score > maxScore)
                {
                    maxScore = score;
                    bestDecision = PossibleDecisions[i];
                }
            }

            bestDecision.QualifierRef.Action.Context = bestDecision.Context;
            return bestDecision;
        }
    }
}
