using NimblesThrowingStuff.Items.Placeables.Blocks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class HadalShellstoneTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMergeDirt[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileMergeDirt[Type] = true;

            ItemDrop/* tModPorter Note: Removed. Tiles and walls will drop the item which places them automatically. Use RegisterItemDrop to alter the automatic drop if necessary. */ = ModContent.ItemType<HadalShellstone>();
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Deep Shellstone");
            AddMapEntry(new Color(8, 72, 107), name);
            MineResist = 2f;
            MinPick = 50;
            DustType = 42;
            HitSound = SoundID.Dig;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f; 
            g = 0.1f;
            b = 0.3f;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanExplode(int i, int j)
        {
            return true; //
        }
    }
}
