using System;
using System.Collections.Generic;
using UnityEngine;

namespace BaseClasses
{
    public abstract class HitBox : MonoBehaviour
    {
        // List of characters to ignore for the hit detection
        private List<CharacterSheet> _ignore;
        
        // Time remaining before the hitbox is destroyed
        private float _aliveTime;
        
        // Property to check if the hitbox is still active (alive time is greater than 0)
        private bool IsAlive
        {
            get => _aliveTime > 0;
        }

        /// <summary>
        /// Unity's Start method. Calls the StartWrapper to initialize the character.
        /// </summary>
        void Start()
        {
            StartWrapper(); // Calls a custom initialization method
        }

        /// <summary>
        /// Unity's Update method. Calls the UpdateWrapper to handle frame updates.
        /// </summary>
        private void Update()
        {
            UpdateWrapper(); // Calls a custom update method each frame
        }
        
        /// <summary>
        /// Initializes the character's attributes and equipment at the start of the game.
        /// </summary>
        protected virtual void StartWrapper()
        {
            // Can be overridden by subclasses to provide specific initialization logic
        }

        /// <summary>
        /// Updates the character's state each frame, applying effects and managing durations.
        /// </summary>
        protected virtual void UpdateWrapper()
        {
            // Destroy the game object if the hitbox is no longer alive
            if (!IsAlive)
            {
                Destroy(gameObject); 
            }

            // Decrease the alive time every frame
            _aliveTime -= Time.deltaTime;
        }

        /// <summary>
        /// Adds a character to the ignore list, so that the hitbox will not interact with them.
        /// </summary>
        public void AddToIgnore(CharacterSheet cs)
        {
            _ignore.Add(cs); // Adds the character to the list of ignored characters
        }

        /// <summary>
        /// Adds a list of characters to the ignore list.
        /// </summary>
        public void AddToIgnore(List<CharacterSheet> characters)
        {
            // Adds each character in the list to the ignore list individually
            foreach (var cs in characters)
            {
                AddToIgnore(cs);
            }
        }

        /// <summary>
        /// Abstract method to apply effects to the character when the hitbox interacts with it.
        /// Must be implemented by derived classes.
        /// </summary>
        protected abstract void Effect(CharacterSheet cs);

        /// <summary>
        /// Unity's OnTriggerEnter method. Called when another collider enters the trigger collider.
        /// </summary>
        private void OnTriggerEnter(Collider other)
        {
            // Attempt to get the CharacterSheet component from the collided object
            CharacterSheet cs = other.gameObject.GetComponent<CharacterSheet>();

            // If no CharacterSheet component is found, or if the character is in the ignore list, exit the method
            if (cs == null || _ignore.Contains(cs))
            {
                return;
            }

            // Apply the effect to the character and add them to the ignore list
            Effect(cs);
            AddToIgnore(cs);
        }
    }
}
