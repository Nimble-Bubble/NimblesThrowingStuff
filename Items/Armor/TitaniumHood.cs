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
    public class TitaniumHood : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases minion damage by 10% and minion slots by 1");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 150000;
            item.rare = 4;
            item.defense = 2; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased minion damage and slots";
            player.maxMinions += 1;
            player.minionDamage += 0.13f;
            player.onHitDodge = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.1f;
            player.maxMinions += 1;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(ItemID.TitaniumBar, 13);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}