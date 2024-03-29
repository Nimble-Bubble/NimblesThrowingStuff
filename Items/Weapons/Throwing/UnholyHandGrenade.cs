using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class UnholyHandGrenade : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Explodes into Greek fireballs");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 73;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 28;
			Item.useTime = 52;
			Item.useAnimation = 52;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 37, 50, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("UnholyHandGrenadeProj").Type;
			Item.shootSpeed = 9f;
            Item.mana = 15;
		}
	}
}