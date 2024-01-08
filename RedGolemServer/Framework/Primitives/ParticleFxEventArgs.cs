using System;

namespace RedGolemServer.Framework.Primitives
{
    public class ParticleFxEventArgs
    {
        public ParticleFxEventArgs(
            int assetHash,
            int axisBitset,
            int effectHash,
            int entityNetId,
            int f100,
            int f105,
            int f106,
            int f107,
            bool f109,
            bool f110,
            bool f111,
            int f92,
            bool isOnEntity,
            float offsetX,
            float offsetY,
            float offsetZ,
            float posX,
            float posY,
            float posZ,
            float rotX,
            float rotY,
            float rotZ,
            float scale)
        {
            AssetHash = assetHash;
            AxisBitset = axisBitset;
            EffectHash = effectHash;
            EntityNetId = entityNetId;
            F100 = f100;
            F105 = f105;
            F106 = f106;
            F107 = f107;
            F109 = f109;
            F110 = f110;
            F111 = f111;
            F92 = f92;
            IsOnEntity = isOnEntity;
            OffsetX = offsetX;
            OffsetY = offsetY;
            OffsetZ = offsetZ;
            PosX = posX;
            PosY = posY;
            PosZ = posZ;
            RotX = rotX;
            RotY = rotY;
            RotZ = rotZ;
            Scale = scale;
        }

        public int AssetHash { get; }
        public int AxisBitset { get; }
        public int EffectHash { get; }
        public int EntityNetId { get; }
        public int F100 { get; }
        public int F105 { get; }
        public int F106 { get; }
        public int F107 { get; }
        public bool F109 { get; }
        public bool F110 { get; }
        public bool F111 { get; }
        public int F92 { get; }
        public bool IsOnEntity { get; }
        public float OffsetX { get; }
        public float OffsetY { get; }
        public float OffsetZ { get; }
        public float PosX { get; }
        public float PosY { get; }
        public float PosZ { get; }
        public float RotX { get; }
        public float RotY { get; }
        public float RotZ { get; }
        public float Scale { get; }
    }
}
