using NimblesThrowingStuff.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Buffs
{
	public class RailcannonCooldown : ModBuff
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Railcannon Cooldown");
			// Description.SetDefault("It burns!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<NimblesPlayer>().railcannonCooldown = true;
		}
	}
}
