namespace BaseClasses
{
    public class Weapon : Equipment
    {
        // To be changed by implemented class
        public int Atk { get; protected set; }

        protected void LightContact(CharacterSheet cs)
        {
            cs.DealDamage((int) (Atk * 0.6f + cs.Atk * 0.4f));
        }
        
        protected void HeavyContact(CharacterSheet cs)
        {
            cs.DealDamage((int) (Atk * 0.8f + cs.Atk * 0.7f));
        }
    }
}