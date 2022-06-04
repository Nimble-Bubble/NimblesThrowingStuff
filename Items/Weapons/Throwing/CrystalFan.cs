using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class CrystalFan : ModItem
	{
		public override void SetDefaults() 
		{
			Item.damage = 27;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("CrystalKnifeProj").Type;
			Item.shootSpeed = 11f;
            Item.mana = 10;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{

				Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
			velocity = perturbedSpeed;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(Mod);
            r.AddIngredient(502, 20);
            r.AddIngredient(520, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.SetResult(this);
            r.AddRecipe();
        }
	}
}