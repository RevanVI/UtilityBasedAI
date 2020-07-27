using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public class ContextBase
    {
        public AIAgent Provider;
        public object Target;
        public Dictionary<string, object> Data = new Dictionary<string, object>();

        public ContextBase Copy()
        {
            ContextBase context = new ContextBase();
            context.Provider = Provider;
            return context;
        }
    }
}
