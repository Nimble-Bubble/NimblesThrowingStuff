using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class BloodyPike : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Turns into a stream of ichor");   
        }
		public override void SetDefaults() 
		{
			Item.damage = 42;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 1;
			Item.knockBack = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 18, 75, 0);
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BloodyPikeProj>();
			Item.shootSpeed = 9f;
            Item.mana = 12;
		}
	}
}