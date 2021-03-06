using NimblesThrowingStuff.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class ProcellariteBarTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileMergeDirt[Type] = false;
            drop = ModContent.ItemType<ProcellariteBar>();
            TileObjectData.newTile.StyleWrapLimit = 18;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Procellarite Bar");
            AddMapEntry(new Color(0, 200, 185), name);
            mineResist = 2f;
            minPick = 210;
            soundType = 21;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
