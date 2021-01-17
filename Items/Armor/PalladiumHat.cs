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
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Palladium Hat");
                Tooltip.SetDefault("Increases thrown critical strike chance by 7% and thrown damage by 13%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 75000;
            item.rare = 4;
            item.defense = 7; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased life regeneration";
            player.onHitRegen = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.13f;
            player.thrownCrit += 6;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(1184, 12);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}