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
	public class Lagieye : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Item.staff[Item.type] = true;
		}
		public override void SetDefaults() 
		{
			Item.damage = 31;
			Item.DamageType = DamageClass.Magic;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 11;
			Item.useAnimation = 11;
			Item.useStyle = 5;
			Item.knockBack = 4f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(0, 2, 41, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
			Item.shoot = ProjectileID.ThunderStaffShot;
			Item.shootSpeed = 20f;
            Item.mana = 6;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack)
        {
                velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LagiacrusShell>(), 12);
            recipe.AddIngredient(ItemID.BlackLens);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}