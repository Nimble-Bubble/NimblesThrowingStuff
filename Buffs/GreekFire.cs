using NimblesThrowingStuff.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Buffs
{
	public class GreekFire : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Greek Fire");
			Description.SetDefault("It burns!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<NimblesPlayer>().greek = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NimblesGlobalNPC>().greek = true;
		}
	}
}
