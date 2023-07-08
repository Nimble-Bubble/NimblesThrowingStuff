using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class TrueAscalon : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("A true masterwork of metalsmithing and machinery."
				+"\nRight click to fire three holy laser beams that each do half of the weapon's base damage. Guard and right click to charge the laser beams."
				+ "\nA single reload gives 4 charges, and you can have up to 12 charges. A single instance of laserfire takes up 3 charges."); */
		}
		public override void SetDefaults()
		{
			Item.damage = 72;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 23;
			Item.useTime = 23;
			Item.knockBack = 7.5f;
			Item.width = 76;
			Item.height = 76;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<TrueAscalonProj>();
			Item.shootSpeed = 15f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.2f;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
				Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity, ModContent.ProjectileType<TrueAscalonEcho>(), damage, knockback, player.whoAmI);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Ascalon>(), 1);
			recipe.AddIngredient(ItemID.ChlorophyteBar, 24);
			recipe.AddIngredient(ItemID.BrokenHeroSword);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}