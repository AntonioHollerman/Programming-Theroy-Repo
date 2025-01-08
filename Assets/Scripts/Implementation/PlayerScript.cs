using Unity;
using BaseClasses;

namespace Implementation
{
    public class PlayerScript : CharacterSheet
    {
        protected override void StartWrapper()
        {
        BaseHp = 9;  // Base health points
        BaseMana = 75; // Base mana points
        BaseAtk = 4; // Base attack power
        BaseSpeed = 7; // Base speed value
        
        base.StartWrapper();
        }

        protected override void UpdateWrapper()
        {
            base.UpdateWrapper();
            WalkCycle();
        }

    //Main Walk Cycle
        private void WalkCycle()
        {
            
        }
    }
}