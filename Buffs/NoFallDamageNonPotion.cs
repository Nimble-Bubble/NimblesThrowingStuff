using NimblesThrowingStuff.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Buffs
{
	public class NoFallDamageNonPotion : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.noFallDmg = true;
		}
	}
}
