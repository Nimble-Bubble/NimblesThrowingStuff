using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class DoradoKnives : ModItem
	{
        public override void SetStaticDefaults()
        {
			DisplayName.SetDefault("Dragon's Fangs");
         Tooltip.SetDefault("Cleave and claw through the toughest hide.");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 58;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("DoradoKniveProj").Type;
			Item.shootSpeed = 15f;
            Item.mana = 8;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("DoradoFragment").Type, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
      int numberProjectiles = 3 + Main.rand.Next(3); 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(10)); 
				Projectile.NewProjectile(Item.GetSource_FromThis(), position, perturbedSpeed, type, damage, Item.knockBack, player.whoAmI);
			}
        }
	}
}