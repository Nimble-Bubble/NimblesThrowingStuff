using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class MythrilHardHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Mythril Hard Hat");
                // Tooltip.SetDefault("Increases thrown damage and velocity by 15%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 112500;
            Item.rare = 4;
            Item.defense = 8; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Throwing critical strike chance increased by 10%";
            player.GetCritChance(DamageClass.Throwing) += 10;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.15f;
            player.ThrownVelocity += 0.15f;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(382, 10);
            r.AddTile(134);
            r.Register();
        }
    }
}