using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public abstract class ActionBase : ScriptableObject
    {
        public int ActionId;
        public ContextBase Context;

        public virtual void Execute()
        {
            return;
        }
    }
}