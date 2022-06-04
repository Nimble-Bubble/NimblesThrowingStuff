using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class LihzahrdSpikeKnife : ModItem
	{

		public override void SetDefaults() 
		{
			Item.damage = 65;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = 1;
			Item.knockBack = 4.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 10, 0);
			Item.rare = 7;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("LihzahrdSpikeKnifeProj").Type;
			Item.shootSpeed = 10f;
            Item.consumable = true;
            Item.maxStack = 999;
		}
	}
}