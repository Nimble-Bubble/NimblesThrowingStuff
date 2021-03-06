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
    public class OrichalcumHornedHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Orichalcum Horned Hat");
                Tooltip.SetDefault("Increases minion damage by 8% and minion slots by 1");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 112500;
            item.rare = 4;
            item.defense = 1; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased minion damage and slots, plus some petals";
            player.maxMinions += 1;
            player.minionDamage += 0.18f;
            player.onHitPetal = true;
            
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.08f;
            player.maxMinions += 1;
        }
        //unfortunately, minions can't crit


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(1191, 12);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}