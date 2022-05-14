using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Summoning;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class AquaBlastCore : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Aqua Blaster Core"); 
			Tooltip.SetDefault("Summons an Aqua Blaster");
            Item.staff[item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[item.type] = true; 
			ItemID.Sets.LockOnIgnoresCollision[item.type] = true;
		}
		public override void SetDefaults() {
			item.damage = 25;
			item.knockBack = 4f;
			item.mana = 11;
			item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.value = Item.buyPrice(0, 7, 50, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item21;
			item.noMelee = true;
			item.summon = true;
			item.buffType = ModContent.BuffType<AquaBlastBuff>();
			item.shoot = ModContent.ProjectileType<AquaBlastProj>();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) 
        {
			player.AddBuff(item.buffType, 18000);
			position = Main.MouseWorld;
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}