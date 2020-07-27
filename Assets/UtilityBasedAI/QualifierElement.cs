﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UtilityAI
{
    [System.Serializable]
    public class QualifierElement
    {
        public string Name;
        public UtilityAISystem.Qualifiers Type;
        public ActionBase Action;

        public Qualifier QualifierPrefab;

        [System.Serializable]
        public struct ConsiderationPair
        {
            public ConsiderationBase Consideration;
            public AnimationCurve ResolveCurve;
        }

        public List<ConsiderationPair> Considerations;

        public virtual float Score(ContextBase context, float minValue, ILogHandler logHandler)
        {
            float modificator = 1 - 1 / Considerations.Count;
            float makeUpValue;
            float score = 1f;
            float compensationScore = 1f;
            for (int i = 0; i < Considerations.Count; ++i)
            {
                float considerationScore = Considerations[i].Consideration.Score(context);
                float curveScore = Considerations[i].ResolveCurve.Evaluate(considerationScore);
                logHandler?.WriteText($"\t\tConsideration {Considerations[i].Consideration.Name}\n\t\t\tscore {considerationScore}\n\t\t\tCurve score {curveScore}\n");
                score *= curveScore;

                //check if we already has worse result (assume that others considerations returns maximum - 1)
                makeUpValue = (1 - score) * modificator;
                compensationScore = score + makeUpValue * score;
                if (compensationScore < minValue)
                {
                    return 0f;
                }
            }

            //compensation
            makeUpValue = (1 - score) * modificator;
            compensationScore = score + makeUpValue * score;
            logHandler?.WriteText($"\t\tTotal score {score}\n\t\tCompensationScore {compensationScore}\n");
            return compensationScore;
        }
    }
}
