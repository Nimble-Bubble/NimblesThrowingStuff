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
    public class MathrusHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            DisplayName.SetDefault("Draconic Helmet");
                Tooltip.SetDefault("Increases mana by 120 and throwing velocity by 60%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 350000;
            Item.rare = 10;
            Item.defense = 15; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("MathrusPlate").Type && legs.type == Mod.Find<ModItem>("MathrusGreaves").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Your throwing damage is increased by 25%, and you emit red light";
            Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 1.5f, 0f, 0f);
            player.GetDamage(DamageClass.Throwing) += 0.25f;
            player.manaFlower = true;
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownHeal = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.ThrownVelocity += 0.6f;
            player.statManaMax2 += 120;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(ModContent.ItemType<DoradoFragment>(), 12);
            r.AddIngredient(3467, 8);
            r.AddTile(TileID.LunarCraftingStation);
            r.Register();
        }
    }
}