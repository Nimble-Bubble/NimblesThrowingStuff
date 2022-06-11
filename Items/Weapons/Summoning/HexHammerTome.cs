using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Summoning;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class HexHammerTome : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Hexed Hammer Tome"); 
			Tooltip.SetDefault("Summons a Breaker");
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 12;
			Item.knockBack = 4f;
			Item.mana = 10;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 1, 35, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item8;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;;
			Item.buffType = ModContent.BuffType<HexHammerBuff>();
			Item.shoot = ModContent.ProjectileType<HexHammerProj>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
        {
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
		}
		 public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DemoniteBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}