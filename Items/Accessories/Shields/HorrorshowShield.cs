using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories.Shields
{
    public class HorrorshowShield : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Makes you completely invisible when guarding");
        }
        public override void SetDefaults()
        {
            Item.accessory = true;
            Item.width = 26;
            Item.height = 26;
            Item.value = Item.value = Item.buyPrice(0, 50, 0, 0);
            Item.rare = 7;
            Item.defense = 5;
        }
        //public override bool CanEquipAccessory(Player player, int slot)
        //{
        //    var modPlayer = player.GetModPlayer<NimblesPlayer>();
        //    if (modPlayer.whichShield >= 1)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.whichShield = 2;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.Mythril);
            recipe.Register();
        }
    }
}
