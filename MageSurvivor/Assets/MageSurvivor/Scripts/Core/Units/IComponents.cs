namespace MageSurvivor
{
    public interface IComponents
    {
        Mover Mover { get; }
        UnitAnimator Animator { get; }

        void AddMover(Mover mover);
        void AddAnimator(UnitAnimator animator);
    }
}
