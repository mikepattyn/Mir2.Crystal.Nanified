using Server.MirDatabase;
using Shared.Enums;
using Shared.Functions;
using S = Shared.Packets.Server.Models;

namespace Server.MirObjects.Monsters
{
    public class OmaSlasher : MonsterObject
    {
        protected internal OmaSlasher(MonsterInfo info)
            : base(info)
        {
        }

        protected override void Attack()
        {
            if (!Target.IsAttackTarget(this))
            {
                Target = null;
                return;
            }

            ActionTime = Envir.Time + 300;
            AttackTime = Envir.Time + AttackSpeed;
            
            Direction = Functions.DirectionFromPoint(CurrentLocation, Target.CurrentLocation);

            Broadcast(new S.ObjectAttack { ObjectID = ObjectID, Direction = Direction, Location = CurrentLocation });

            int damage = GetAttackPower(Stats[Stat.MinDC], Stats[Stat.MaxDC]);
            if (damage == 0) return;

            HalfmoonAttack(damage);
        }
    }
}
