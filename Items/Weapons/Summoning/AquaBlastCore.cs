using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Buffs;
using NimblesThrowingStuff.Projectiles.Summoning;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Summoning
{
	public class AquaBlastCore : ModItem
	{
        public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Aqua Blaster Core"); 
			// Tooltip.SetDefault("Summons an Aqua Blaster");
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; 
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 25;
			Item.knockBack = 4f;
			Item.mana = 11;
			Item.width = 42;
			Item.height = 42;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item21;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;;
			Item.buffType = ModContent.BuffType<AquaBlastBuff>();
			Item.shoot = ModContent.ProjectileType<AquaBlastProj>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			player.AddBuff(Item.buffType, 18000);
			position = Main.MouseWorld;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}