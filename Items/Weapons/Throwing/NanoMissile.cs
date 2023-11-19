using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class NanoMissile : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Nanite Missile");
			// Tooltip.SetDefault("Are you sure this is legal?");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 75;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 10f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(2, 0, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("NanoMissileProj").Type;
			Item.shootSpeed = 10f;
            Item.mana = 20;
		}
	}
}