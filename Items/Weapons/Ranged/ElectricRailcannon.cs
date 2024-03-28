using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Weapons.Melee;
using CsvHelper.TypeConversion;
using NimblesThrowingStuff.Tiles.Furniture;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Ranged;
//using System.Numerics;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ElectricRailcannon : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 640;
			Item.width = 64;
			Item.height = 32;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(40, 0, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.UseSound = SoundID.Zombie104;
			Item.shoot = ModContent.ProjectileType<ElectricRailcannonProj>();
            Item.knockBack = 8f;
			Item.shootSpeed = 5f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
			Item.buffType = ModContent.BuffType<RailcannonCooldown>();
		}
        public override bool CanUseItem(Player player)
        {
            return !player.GetModPlayer<NimblesPlayer>().railcannonCooldown;
        }
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
        {
			int cooldownTime = 960;
			player.AddBuff(Item.buffType, cooldownTime);
		}
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ShroomiteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}