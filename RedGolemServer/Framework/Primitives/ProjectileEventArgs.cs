namespace RedGolemServer.Framework.Primitives
{
    public class ProjectileEventArgs
    {
        public ProjectileEventArgs(
            bool commandFireSingleBullet,
            int effectGroup,
            float firePositionX,
            float firePositionY,
            float firePositionZ,
            float initialPositionX,
            float initialPositionY,
            float initialPositionZ,
            int ownerId,
            int projectileHash,
            int targetEntity,
            int throwTaskSequence,
            int unk10,
            int unk11,
            int unk12,
            int unk13,
            int unk14,
            int unk15,
            int unk16,
            int unk3,
            int unk4,
            int unk5,
            int unk6,
            int unk7,
            int unk9,
            int unkX8,
            int unkY8,
            int unkZ8,
            int weaponHash)
        {
            CommandFireSingleBullet = commandFireSingleBullet;
            EffectGroup = effectGroup;
            FirePositionX = firePositionX;
            FirePositionY = firePositionY;
            FirePositionZ = firePositionZ;
            InitialPositionX = initialPositionX;
            InitialPositionY = initialPositionY;
            InitialPositionZ = initialPositionZ;
            OwnerId = ownerId;
            ProjectileHash = projectileHash;
            TargetEntity = targetEntity;
            ThrowTaskSequence = throwTaskSequence;
            Unk10 = unk10;
            Unk11 = unk11;
            Unk12 = unk12;
            Unk13 = unk13;
            Unk14 = unk14;
            Unk15 = unk15;
            Unk16 = unk16;
            Unk3 = unk3;
            Unk4 = unk4;
            Unk5 = unk5;
            Unk6 = unk6;
            Unk7 = unk7;
            Unk9 = unk9;
            UnkX8 = unkX8;
            UnkY8 = unkY8;
            UnkZ8 = unkZ8;
            WeaponHash = weaponHash;
        }

        public bool CommandFireSingleBullet { get; }
        public int EffectGroup { get; }
        public float FirePositionX { get; }
        public float FirePositionY { get; }
        public float FirePositionZ { get; }
        public float InitialPositionX { get; }
        public float InitialPositionY { get; }
        public float InitialPositionZ { get; }
        public int OwnerId { get; }
        public int ProjectileHash { get; }
        public int TargetEntity { get; }
        public int ThrowTaskSequence { get; }
        public int Unk10 { get; }
        public int Unk11 { get; }
        public int Unk12 { get; }
        public int Unk13 { get; }
        public int Unk14 { get; }
        public int Unk15 { get; }
        public int Unk16 { get; }
        public int Unk3 { get; }
        public int Unk4 { get; }
        public int Unk5 { get; }
        public int Unk6 { get; }
        public int Unk7 { get; }
        public int Unk9 { get; }
        public int UnkX8 { get; }
        public int UnkY8 { get; }
        public int UnkZ8 { get; }
        public int WeaponHash { get; }
    }
}
