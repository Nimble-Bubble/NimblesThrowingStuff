using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Summoning;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class GuardianStaff : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Miniature Guardian Staff"); 
			Tooltip.SetDefault("Summons a small Guardian of the Sky Sea");
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; 
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 50;
			Item.knockBack = 6f;
			Item.mana = 18;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item21;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;;
			Item.buffType = ModContent.BuffType<MiniSkyseaGuardianBuff>();
			Item.shoot = ModContent.ProjectileType<SkySeaGuardianProj>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
        {
			player.AddBuff(Item.buffType, 18000);
			position = Main.MouseWorld;
		}
	}
}