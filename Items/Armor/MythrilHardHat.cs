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
    public class MythrilHardHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Hard Hat");
                Tooltip.SetDefault("Increases thrown damage and velocity by 15%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 112500;
            item.rare = 4;
            item.defense = 8; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Throwing critical strike chance increased by 10%";
            player.thrownCrit += 10;
        }
        public override void UpdateEquip(Player player)
        {
            player.thrownDamage += 0.15f;
            player.thrownVelocity += 0.15f;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(382, 10);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}