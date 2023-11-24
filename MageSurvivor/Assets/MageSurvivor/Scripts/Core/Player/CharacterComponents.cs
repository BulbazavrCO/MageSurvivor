using UnityEngine;

namespace MageSurvivor
{
    public class CharacterComponents : MonoBehaviour, ICharacterComponents
    {
        public Mover Mover { get; private set; }
        public UnitAnimator Animator { get; private set; }
        public BonusHolder BonusHolder { get; private set; }

        public void AddAnimator(UnitAnimator animator)
        {
            Animator = animator;
        }

        public void AddBonusHolder(BonusHolder bonusHolder)
        {
            BonusHolder = bonusHolder;
        }

        public void AddMover(Mover mover)
        {
            Mover = mover;
        }
    }
}
