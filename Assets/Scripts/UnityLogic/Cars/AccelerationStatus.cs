using System;
using System.Runtime.CompilerServices;

namespace Klyukay.UnityLogic.Cars
{
    [Flags]
    public enum AccelerationStatus
    {
        NoMoving = 0b0000,
        AccelPressed = 0b0001,
        DeAccelPressed = 0b0010,
        AccelPressedFirst = 0b0100,
    }

    public static class AccelerationStatusExtensions
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAccelerationPressed(this AccelerationStatus status)
        {
            return (status & AccelerationStatus.AccelPressed) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAccelerationPressedFirst(this AccelerationStatus status)
        {
            return status.IsAccelerationPressed() && (status & AccelerationStatus.AccelPressedFirst) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDeAccelerationPressed(this AccelerationStatus status)
        {
            return (status & AccelerationStatus.DeAccelPressed) != 0;
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsDeAccelerationPressedFirst(this AccelerationStatus status)
        {
            return status.IsDeAccelerationPressed() && (status & AccelerationStatus.AccelPressedFirst) == 0;
        }
    }
    
}