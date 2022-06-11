using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Summoning;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class MossyHornetStaff : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Mossy Hornet Staff"); 
			Tooltip.SetDefault("Summons miniature moss hornets that fire stingers");
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; // This lets the player target anywhere on the whole screen while using a controller.
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 35;
			Item.knockBack = 4f;
			Item.mana = 10;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 27, 50, 0);
			Item.rare = 7;
			Item.UseSound = SoundID.Item8;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;;
			Item.buffType = ModContent.BuffType<MossHornetBuff>();
			Item.shoot = ModContent.ProjectileType<MiniMossHornetProj>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
        {
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(1006, 12); //modded materials
			recipe.AddIngredient(2364, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}