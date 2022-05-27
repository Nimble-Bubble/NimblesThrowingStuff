using NimblesThrowingStuff.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Buffs
{
	public class CompromisedStructure : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Compromised Structure");
			Description.SetDefault("If it can't fly, now it can.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<NimblesPlayer>().compromise = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NimblesGlobalNPC>().compromise = true;
		}
	}
}
