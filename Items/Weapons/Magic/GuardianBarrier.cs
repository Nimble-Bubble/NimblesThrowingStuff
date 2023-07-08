using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class GuardianBarrier : ModItem
	{
        public override void SetStaticDefaults() 
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Barrier Builder"); 
			/* Tooltip.SetDefault("Creates two barriers at the position of the cursor that will move opposite of each other"
				+"\nLeft click will create tall walls that move horizontally"
				+"\nRight click will create wide walls that move vertically"); */
            Item.staff[Item.type] = true;
            ItemID.Sets.GamepadWholeScreenUseRange[Item.type] = true; 
			ItemID.Sets.LockOnIgnoresCollision[Item.type] = true;
		}
		public override void SetDefaults() {
			Item.damage = 125;
			Item.knockBack = 8f;
			Item.mana = 12;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 75, 0, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item8;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.shoot = ModContent.ProjectileType<MagicHorizontalWall>();
			Item.autoReuse = true;
		}
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) 
        {
			position = Main.MouseWorld;
			if (Main.mouseRight)
            {
				type = ModContent.ProjectileType<MagicVerticalWall>();
				velocity = new Vector2(0, 1);
				Projectile.NewProjectile(player.GetSource_FromThis(), position, new Vector2(0, -1), type, damage, knockback, Main.myPlayer);
            }
			else
            {
				type = ModContent.ProjectileType<MagicHorizontalWall>();
				velocity = new Vector2(1, 0);
				Projectile.NewProjectile(player.GetSource_FromThis(), position, new Vector2(-1, 0), type, damage, knockback, Main.myPlayer);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12); 
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}