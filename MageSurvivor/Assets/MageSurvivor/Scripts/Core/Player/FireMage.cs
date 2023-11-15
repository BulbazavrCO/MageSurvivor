using System;
using UnityEngine;
using MageSurvivor.Configs;

namespace MageSurvivor
{
    public class FireMage : MonoBehaviour, IPlayer, IDisposable
    {
        public event Action Died = () => { };

        private IHealth _health;
        private IGameConfiguration _gameConfiguration;

        private StatsProvider _statsProvider;

        private void Awake()
        {
            _gameConfiguration = CompositionRoot.GetGameConfiguration();

            _statsProvider = new StatsProvider();
            _health = new Health(_statsProvider);
        }

        public void Dispose()
        {
            _health.Dying -= Die;
            _statsProvider.Clear();
        }

        public void Setup(CharacterInfo character)
        {
            var characterConfig = _gameConfiguration.GetCharacter(character.ID);
            _statsProvider.Setup(characterConfig.Stats, character.Level);
            _health.Setup();
            _health.Dying += Die;
        }

        public float GetStatValue(EStats type)
        {
            return _statsProvider.GetStatValue(type);
        }

        public bool IsAlive()
        {
            return _health.HealthPoints > 0;
        }

        public void Move(Vector2 direction)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void AddModifier(Modifier modifier)
        {
            _statsProvider.AddModifier(modifier);
        }

        public void RemoveModifier(Modifier modifier)
        {
            _statsProvider.RemoveModifier(modifier);
        }

        private void Die()
        {
            Died();
            Dispose();
        }        
    }
}
