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
    public class ChlorophyteHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Chlorophyte Hat");
                Tooltip.SetDefault("Increases thrown damage by 16% and thrown critical strike chance by 6%"
                                +"\nThrowing weapons poison and envenom enemies");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 300000;
            Item.rare = 7;
            Item.defense = 16; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 1004 && legs.type == 1005;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Summons a powerful leaf crystal to shoot at nearby enemies";
            player.AddBuff(60, 2);
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.16f;
            player.GetCritChance(DamageClass.Throwing) += 6;
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.chloroThrow = true;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(1006, 12);
            r.AddTile(134);
            r.Register();
        }
    }
}