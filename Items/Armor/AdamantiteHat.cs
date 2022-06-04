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
    public class AdamantiteHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Adamantite Hat");
                Tooltip.SetDefault("Increases thrown damage by 24% and thrown critical strike chance by 8%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 150000;
            Item.rare = 4;
            Item.defense = 10; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.AdamantiteBreastplate && legs.type == ItemID.AdamantiteLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "33% chance to not consume weapons";
            player.thrownCost33 = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.24f;
            player.thrownCrit += 8;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(Mod);
            r.AddIngredient(391, 12);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}