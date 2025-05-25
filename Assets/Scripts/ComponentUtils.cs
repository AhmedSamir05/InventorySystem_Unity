using UnityEngine;

public static class ComponentUtils
{
    // Searches for all the parents till get the desired component
    public static T GetComponentInParents<T>(this Transform child, bool includeSelf = false) where T : Component
    {
        Transform current = includeSelf ? child : child.parent;

        while (current != null)
        {
            T component = current.GetComponent<T>();
            if (component != null)
                return component;

            current = current.parent;
        }

        return null;
    }
}
