using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FestiveHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            Tooltip.SetDefault("Increases mana by 100 and throwing velocity by 40%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 500000;
            Item.rare = 8;
            Item.defense = 12; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("FestiveShirt").Type && legs.type == Mod.Find<ModItem>("FestivePants").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You drop spike balls when hit, and your throwing damage is increased by 20%";
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.canSanta = true;
            player.GetDamage(DamageClass.Throwing) += 0.2f;
        }
        public override void UpdateEquip(Player player)
        {
            player.ThrownVelocity += 0.4f;
            player.statManaMax2 += 100;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<FestiveCloth>(), 12);
            r.AddTile(134);
            r.Register();
        }
    }
}