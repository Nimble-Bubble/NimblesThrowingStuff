using NimblesThrowingStuff.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Buffs
{
	public class HermitaurBoost : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Daimyo's Blessing");
			// Description.SetDefault("Endurance increased by 25%");
		}

		public override void Update(Player player, ref int buffIndex) {
			player.endurance += 0.25f;
		}
	}
}
