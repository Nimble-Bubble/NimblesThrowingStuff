using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class LumiKnife : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 79;
			item.thrown = true;
			item.width = 34;
			item.height = 34;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 30, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LumiKnifeProj");
			item.shootSpeed = 7f;
            item.consumable = true;
            item.maxStack = 999;
		}
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
      int numberProjectiles = 2 + Main.rand.Next(3); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); 
				Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
			}
			return false;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(3467);
            r.AddTile(TileID.LunarCraftingStation);
            r.SetResult(this, 111);
            r.AddRecipe();
        }
	}
}