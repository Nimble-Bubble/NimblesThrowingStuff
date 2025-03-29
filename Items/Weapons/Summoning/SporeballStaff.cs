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
	public class SporeballStaff : ModItem
	{
        public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; 
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 14;
			Item.knockBack = 4f;
			Item.mana = 10;
			Item.width = 34;
			Item.height = 36;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 2, 70, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item8;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Summon;;
			Item.buffType = ModContent.BuffType<SporeballBuff>();
			Item.shoot = ModContent.ProjectileType<SporeballProj>();
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
        {
			player.AddBuff(Item.buffType, 2);
			position = Main.MouseWorld;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(331, 12); 
			recipe.AddIngredient(209, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}