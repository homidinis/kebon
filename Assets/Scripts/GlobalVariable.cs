using System.Collections;
using System.Collections.Generic;

public class GlobalVariable
{
    public static string[,] arrayMasak =
    { // 1 ke kanan, 0 ke bawah
        { "Pokchoi Siram Jamur", "Sprites/Kangkung_2", "Pokchoi x1\nBawang x1\nJamur x1\nKecap x1"},
        { "Resep B", "Sprites/Kangkung_1","Pokchoi x1\nBawang x1\nJamur x1\nKecap x1"},
        { "Resep C", "Sprites/Kangkung_2","Pokchoi x1\nBawang x1\nJamur x1\nKecap x1"},

    };
    public static string[][] jaggedArray =
    {
        new string[]
            {"Pokchoi","Bawang","Jamur","Kecap"},
        new string[]
            {"Pokchoi","Bawang","Kecap","SausTiram"},
        new string[]
            {"Pokchoi","Bawang","SausTiram","Tahu","Cabai"},

        new string[]
            {"Selada","Bawang","Jamur","SausTiram"},
        new string[]
            {"Selada","Telur","Kecap","Margarin"},

        new string[]
            {"Kangkung","Bawang","SausTiram","Tempe"},
        new string[]
            {"Kangkung","Bawang","SausTiram","Cabai"},

        new string[]
            {"Jagung","Bawang","SausTiram","Tempe"},
        new string[]
            {"Jagung","Bawang","SausTiram","Cabai"},
        new string[]
            {"Jagung","Bawang","SausTiram","Tempe"},
        new string[]
            {"Jagung","Bawang","SausTiram","Cabai"},
    };
    public static string[,] arrayMarket =
    { // 1 ke kanan, 0 ke bawah
        { "Telur", "Sprites/Kangkung_2", "50" },
        { "Jamur", "Sprites/Kangkung_1", "100" },
        { "Kecap", "Sprites/Kangkung_2", "20" },
        { "SausTiram", "Sprites/Kangkung_2", "50" },
        { "Tahu", "Sprites/Kangkung_1", "100" },
        { "Tempe", "Sprites/Kangkung_2", "20" },
        { "Cabai", "Sprites/Kangkung_2", "50" },
        { "Margarin", "Sprites/Kangkung_1", "100" },
        { "Tepung", "Sprites/Kangkung_2", "20" },
        { "Minyak", "Sprites/Kangkung_2", "20" }

    };
}