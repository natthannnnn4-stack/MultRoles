
namespace MultRoles
{
    public enum SheriffShotResult
    {
        Cooldown,
        Meeting,
        NoTarget,
        InvalidTime,
        HitImpostor,
        Misfire
    }

    public sealed class SheriffLogic
    {
        public const float CooldownSeconds = 30f;

        private float nextShotTime;

        public float GetRemainingCooldown(float currentTime)
        {
            if (!float.IsFinite(currentTime))
                return CooldownSeconds;

            return Math.Max(0f, nextShotTime - currentTime);
        }

        public SheriffShotResult TryShoot(
            float currentTime,
            bool meetingActive,
            bool hasTarget,
            bool targetIsImpostor)
        {
            if (!float.IsFinite(currentTime))
                return SheriffShotResult.InvalidTime;

            if (meetingActive)
                return SheriffShotResult.Meeting;

            if (currentTime < nextShotTime)
                return SheriffShotResult.Cooldown;

            if (!hasTarget)
                return SheriffShotResult.NoTarget;

            nextShotTime = currentTime + CooldownSeconds;

            return targetIsImpostor
                ? SheriffShotResult.HitImpostor
                : SheriffShotResult.Misfire;
        }
    }
}
