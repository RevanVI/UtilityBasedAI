using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI
{
    public interface AIAgent
    {
        Character GetControlledCharacter();

        ContextBase GetContext();
    }
}
