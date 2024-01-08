namespace RedGolemServer.Framework.Primitives
{
    public class WeaponDamageEventArgs
    {
        public WeaponDamageEventArgs(
            int actionResultId,
            int actionResultName,
            int damageFlags,
            int damageTime,
            int damageType,
            int f104,
            bool f112,
            int f112_1,
            int f120,
            int f133,
            bool hasActionResult,
            bool hasImpactDir,
            bool hasVehicleData,
            int hitComponent,
            bool hitEntityWeapon,
            int hitGlobalId,
            int[] hitGlobalIds,
            bool hitWeaponAmmoAttachment,
            float impactDirX,
            float impactDirY,
            float impactDirZ,
            bool isNetTargetPos,
            float localPosX,
            float localPosY,
            float localPosZ,
            bool overrideDefaultDamage,
            int parentGlobalId,
            bool silenced,
            int suspensionIndex,
            int tyreIndex,
            int weaponDamage,
            int weaponType,
            bool willKill)
        {
            ActionResultId = actionResultId;
            ActionResultName = actionResultName;
            DamageFlags = damageFlags;
            DamageTime = damageTime;
            DamageType = damageType;
            F104 = f104;
            F112 = f112;
            F112_1 = f112_1;
            F120 = f120;
            F133 = f133;
            HasActionResult = hasActionResult;
            HasImpactDir = hasImpactDir;
            HasVehicleData = hasVehicleData;
            HitComponent = hitComponent;
            HitEntityWeapon = hitEntityWeapon;
            HitGlobalId = hitGlobalId;
            HitGlobalIds = hitGlobalIds;
            HitWeaponAmmoAttachment = hitWeaponAmmoAttachment;
            ImpactDirX = impactDirX;
            ImpactDirY = impactDirY;
            ImpactDirZ = impactDirZ;
            IsNetTargetPos = isNetTargetPos;
            LocalPosX = localPosX;
            LocalPosY = localPosY;
            LocalPosZ = localPosZ;
            OverrideDefaultDamage = overrideDefaultDamage;
            ParentGlobalId = parentGlobalId;
            Silenced = silenced;
            SuspensionIndex = suspensionIndex;
            TyreIndex = tyreIndex;
            WeaponDamage = weaponDamage;
            WeaponType = weaponType;
            WillKill = willKill;
        }

        public int ActionResultId { get; }
        public int ActionResultName { get; }
        public int DamageFlags { get; }
        public int DamageTime { get; }
        //The timestamp the damage was originally inflicted at.This should match the global network timer.

        public int DamageType { get; }
        //A value(between 0 and 3) containing an internal damage type.Specific values are currently unknown.

        public int F104 { get; }
        public bool F112 { get; }
        public int F112_1 { get; }
        public int F120 { get; }
        public int F133 { get; }
        public bool HasActionResult { get; }
        public bool HasImpactDir { get; }
        public bool HasVehicleData { get; }
        public int HitComponent { get; }
        public bool HitEntityWeapon { get; }
        //Whether the damage should be inflicted as if it hit the weapon the entity is carrying.This likely applies to grenades being hit, which should explode, but also normal weapons, which should not harm the player much.
        public int HitGlobalId { get; }
        //The network ID of the victim entity.

        public int[] HitGlobalIds { get; }
        //An array containing network IDs of victim entities.If there is more than one, the first one will be set in hitGlobalId.
        public bool HitWeaponAmmoAttachment { get; }
        //Whether the damage should be inflicted as if it hit an ammo attachment component on the weapon.This applies to players/peds carrying weapons where another player shooting the ammo component makes the weapon explode.

        public float ImpactDirX { get; }
        public float ImpactDirY { get; }
        public float ImpactDirZ { get; }
        public bool IsNetTargetPos { get; }
        public float LocalPosX { get; }
        public float LocalPosY { get; }
        public float LocalPosZ { get; }
        public bool OverrideDefaultDamage { get; }
        //If set, 'weaponDamage' is valid.If unset, the game infers the damage from weapon metadata.

        public int ParentGlobalId { get; }
        public bool Silenced { get; }
        //Set when the damage is applied using a silenced weapon.

        public int SuspensionIndex { get; }
        public int TyreIndex { get; }
        public int WeaponDamage { get; }
        //The amount of damage inflicted, if overrideDefaultDamage is set.If not, this value is set to 0.

        public int WeaponType { get; }
        //The weapon hash for the inflicted damage.

        public bool WillKill { get; }
        //Whether the originating client thinks this should be instantly-lethal damage, such as a critical headshot.
    }
}
