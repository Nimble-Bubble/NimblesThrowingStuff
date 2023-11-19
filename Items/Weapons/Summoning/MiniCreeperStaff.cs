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
	public class MiniCreeperStaff : ModItem
	{
        public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; 
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 20;
			Item.knockBack = 4f;
			Item.mana = 8;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 2, 70, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;;
			Item.buffType = ModContent.BuffType<MiniCreeperBuff>();
			Item.shoot = ModContent.ProjectileType<MiniCreeperProj>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			player.AddBuff(Item.buffType, 18000);
			position = Main.MouseWorld;
		}
		public override void AddRecipes()
		{
			/* Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
			recipe.AddIngredient(ItemID.TissueSample, 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register(); */
		}
	}
}