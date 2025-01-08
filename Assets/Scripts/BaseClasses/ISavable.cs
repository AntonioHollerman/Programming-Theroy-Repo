using UnityEngine;

namespace BaseClasses
{
    public interface ISavable
    {
        protected Transform GetGameObject();

        public virtual void WriteToDatabase()
        {
            
        }

        public virtual void CreateFromDatabase()
        {
            
        }
    }
}