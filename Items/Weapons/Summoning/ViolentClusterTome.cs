using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Summoning;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class ViolentClusterTome : ModItem
	{
        public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Violent Chopper Tome"); 
			Tooltip.SetDefault("Summons a Blood Lust Cluster");
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; 
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 16;
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
			Item.buffType = ModContent.BuffType<ViolentClusterBuff>();
			Item.shoot = ModContent.ProjectileType<ViolentClusterProj>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
        {
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
		}
		 public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}