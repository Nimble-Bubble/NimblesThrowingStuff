using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Summoning;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class SporeballStaff : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Sporeball Staff"); 
			Tooltip.SetDefault("Summons poisonous spore balls");
            Item.staff[item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 8;
			item.knockBack = 4f;
			item.mana = 10;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 2, 70, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item8;
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<SporeballBuff>();
			item.shoot = ModContent.ProjectileType<SporeballProj>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) 
        {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(331, 12); //modded materials
			recipe.AddIngredient(209, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}