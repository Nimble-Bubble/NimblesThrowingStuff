using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FestivePants : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Festive Boots");
                Tooltip.SetDefault("Increases movement speed by 25% and throwing damage by 30%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 750000;
            item.rare = 8;
            item.defense = 16; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.25f;
            player.thrownDamage += 0.3f;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(mod.ItemType("FestiveCloth"), 18);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}