using System;
using MageSurvivor.Configs;
using MageSurvivor.CharacterBehaviorStates;
using UnityEngine;

namespace MageSurvivor
{
    public abstract class BaseCharacter : MonoBehaviour, IPlayer, ICharacterComponents
    {
        public event Action Died = () => { };
        public event Action HealthChanged = () => { };

        private IHealth _health;
        private IGameConfiguration _gameConfiguration;       

        private StatsProvider _statsProvider;
        protected ICharacterBehavior _behavior;       

        public Mover Mover { get; private set; }       
        public UnitAnimator Animator { get; private set; }
        public BonusHolder BonusHolder { get; private set; }

        public Transform Pivot => transform;

        protected virtual void Awake()
        {
            _gameConfiguration = CompositionRoot.GetGameConfiguration();           

            _statsProvider = new StatsProvider();
            _health = new Health(_statsProvider);

            var input = CompositionRoot.GetInput();
            _behavior = new CharacterBehavior(this, input);           
        }

        private void Update()
        {
            _behavior.Update();
            SpellUsed();
        }

        public void Dispose()
        {
            _health.Dying -= Die;
            _health.HealthChanged -= HandleHealthChanged;
            _statsProvider.StatsChanged -= HandleStatsChanged;

            _statsProvider.Clear();
            gameObject.SetActive(false);
        }

        public void Setup(CharacterInfo character)
        {
            var characterConfig = _gameConfiguration.GetCharacter(character.ID);
            _statsProvider.Setup(characterConfig.Stats, character.Level);
            _health.Setup();          
            _health.Dying += Die;
            _health.HealthChanged += HandleHealthChanged;
            _statsProvider.StatsChanged += HandleStatsChanged;
        }

        public float GetStatValue(EStats type)
        {
            return _statsProvider.GetStatValue(type);
        }

        public bool IsAlive()
        {
            return _health.HealthPoints > 0;
        }        

        public void AddModifier(Modifier modifier)
        {
            _statsProvider.AddModifier(modifier);
        }

        public void RemoveModifier(Modifier modifier)
        {
            _statsProvider.RemoveModifier(modifier);
        }

        public void TakeDamage(float value)
        {
            _health.Hit(value);
        }

        public void AddMover(Mover mover)
        {
            Mover = mover;
        }

        public void AddAnimator(UnitAnimator animator)
        {
            Animator = animator;
        }

        public void AddBonusHolder(BonusHolder bonusHolder)
        {
            BonusHolder = bonusHolder;
        }

        public float GetHealthPercent()
        {
            return _health.GetHealthPercent();
        }

        public abstract void SpellUsed();

        private void Die()
        {
            Died();
            _behavior.Die();         
        }

        private void HandleHealthChanged()
        {
            HealthChanged();
        }

        private void HandleStatsChanged()
        {
            _health.StatsChanged();
            _behavior.StatsChaged();            
        }
    }
}
