using NimblesThrowingStuff.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Buffs
{
	public class GuardianPotionBuff : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Daimyo's Blessing");
			// Description.SetDefault("Endurance increased by 25%");
			Main.pvpBuff[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.guardBonus += 25;
		}
	}
}
