using UnityEngine;

namespace BaseClasses
{
    public class Equipment : ISavable
    {
        // To be changed by implemented class
        public string GearType { get; protected set; }
        protected Transform Self;
        Transform ISavable.GetGameObject()
        {
            return Self;
        }
    }
}