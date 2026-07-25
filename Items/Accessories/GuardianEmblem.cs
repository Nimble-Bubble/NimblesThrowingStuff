using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Accessories
{
    public class GuardianEmblem : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 28;
            Item.height = 28;
			//This was originally 39G, 39S, 39C as a SELL price, but I recently figured that was absurd compared to the Destroyer Emblem's 6G
            //Accessory reforging usually isn't as bad as weapon reforging since there are no negative effects and the prices usually don't go that much higher than base
			//But I figured it still made sense to make things cheaper
			Item.value = Item.sellPrice(0, 8, 0, 0);
            Item.rare = ItemRarityID.Red;
            Item.expert = false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) += 15;
            player.GetDamage(DamageClass.Generic) += 0.15f;
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12); 
            recipe.AddIngredient(1301, 1);
			recipe.AddTile(412);
			recipe.Register();
		}
    }
}
