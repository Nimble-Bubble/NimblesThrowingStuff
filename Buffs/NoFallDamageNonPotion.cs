using NimblesThrowingStuff.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Buffs
{
	public class NoFallDamageNonPotion : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Fearless Fall");
			// Description.SetDefault("Fall without fear, for you will not be hurt");
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.noFallDmg = true;
		}
	}
}
