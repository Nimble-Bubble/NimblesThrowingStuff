using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Tiles.Furniture;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class BubbleJackhammer : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Fires a wheel of rainwater");
            Item.staff[Item.type] = false;
		}
		public override void SetDefaults() 
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Magic;
			Item.width = 68;
			Item.height = 24;
			Item.useTime = 7;
			Item.useAnimation = 7;
			Item.useStyle = 5;
			Item.knockBack = 3f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(1, 25, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item61;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.Bubble;
			Item.shootSpeed = 24f;
            Item.mana = 6;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
				perturbedSpeed *= new Vector2(Main.rand.NextFloat(0.9f, 1.1f), Main.rand.NextFloat(0.9f, 1.1f));
                Projectile.NewProjectile(player.GetSource_FromThis(), position, perturbedSpeed, type, damage, knockBack, player.whoAmI);
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
            recipe.AddIngredient(ItemID.BubbleGun);
            recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
            recipe.Register();
        }
    }
}