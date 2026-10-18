using System;

namespace MultRoles
{
    public enum SheriffShotResult
    {
        Cooldown,
        Meeting,
        NoTarget,
        HitImpostor,
        Misfire
    }

    public sealed class SheriffLogic
    {
        public const float CooldownSeconds = 30f;

        private float nextShotTime = 0f;

        public SheriffShotResult TryShoot(
            float currentTime,
            bool meetingActive,
            bool hasTarget,
            bool targetIsImpostor)
        {
            if (meetingActive)
                return SheriffShotResult.Meeting;

            if (currentTime < nextShotTime)
                return SheriffShotResult.Cooldown;

            if (!hasTarget)
                return SheriffShotResult.NoTarget;

            nextShotTime = currentTime + CooldownSeconds;

            if (targetIsImpostor)
                return SheriffShotResult.HitImpostor;

            return SheriffShotResult.Misfire;
        }
    }
}
