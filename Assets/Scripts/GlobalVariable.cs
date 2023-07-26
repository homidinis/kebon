using System.Collections;
using System.Collections.Generic;

public class GlobalVariable
{
    public static string[,] arrayResep =
    { // 1 ke kanan, 0 ke bawah
        { "Pokchoi Siram Jamur", "Sprites/makanan/Makan/Makan_Pokchoi_Jamur", "Pokchoi x1\nBawang x1\nJamur x1\nKecap x1"},
        { "Pokchoi Saus Tiram", "Sprites/makanan/Makan/Makan_Pokchoi_SausTiram","Pokchoi x1\nBawang x1\nKecap x1\nSaus Tiram x1"},
        { "Tumis Pakchoi Tahu", "Sprites/makanan/Makan/Makan_Pokchoi_Tahu","Pokchoi x1\nBawang x1\nSaus Tiram x1\nTahu x1\nCabai"},
        
        { "Tumis Selada Jamur", "Sprites/makanan/Makan/Makan_Selada_TumisJamur", "Selada x1\n Bawang x1 \n Jamur x1\n Kecap x1"},
        { "Telur Dadar Selada","Sprites/makanan/Makan/Makan_Selada_TelurGulung","Selada x1\n Telur x1\n Kecap x1\n Margarin x1"},

        { "Kangkung Tempe","Sprites/makanan/Makan/Makan_Kangkung_TumisTempe","Kangkung x1 \n Bawang x1 \n Saus Tiram x1 \n Tempe x1" },
        { "Cah Kangkung","Sprites/makanan/Makan/Makan_Kangkung_Tumis","Kangkung x1 \n Bawang x1 \n Saus Tiram x1\n Cabai x1"},

        { "Jagung Bakar", "Sprites/makanan/Makan/Makan_Jagung_Bakar","Jagung x1\n Margarin x1" },
        { "Tumis Jagung Bakar","Sprites/makanan/Makan/Makan_Jagung_Tumis","Jagung Bakar x1\n Bawang x1\n Cabai x1" },
        { "Jagung Jamur Asam Manis","Sprites/makanan/Makan/Makan_Jagung_SiramJamur","Jagung x1 \n Jamur x1 \n Saus Tiram x1 \n Cabai x1 \n"},
        { "Sup Jagung","Sprites/makanan/Makan/Makan_Jagung_Sup","Jagung x1 \n Bawang x1 \n Telur x1 \n Tepung x1"},

        { "Cincin Bawang","Sprites/makanan/Makan/Makan_Bawang_Goreng","Bawang x1 \n Tepung x1 \n Minyak x1"},

        { "Tumis Edamame","Sprites/makanan/Makan/Makan_Edamame_Tumis", "Edamame x1 \n Bawang x1 \n Kecap x1 \n Margarin x1"},
        { "Edamame Goreng","Sprites/makanan/Makan/Makan_Edamame_Goreng" , "Edamame x1 \n Bawang x1 \n Minyak x1 \n"},

        { "Nasi Goreng Edamame","Sprites/makanan/Makan/Makan_NasiGoreng_edamame" , "Nasi x1 \n Edamame x1 \n Bawang x1 \n Kecap x1 \n Cabai x1 \n Minyak x1"},
        { "Nasi Goreng Jagung","Sprites/makanan/Makan/Makan_NasiGoreng_Jagung" , "Nasi x1 \n Jagung x1 \n Bawang x1 \n Kecap x1 \n Cabai x1 \n Minyak x1"},

        { "Telur Rebus","Sprites/makanan/Makan/Makan_Telur_Rebus","Telur x1" },
        { "Telur Ceplok","Sprites/makanan/Makan/Makan_Telur_Ceplok","Telur x1 \n Minyak x1" },
        { "Telur Dadar","Sprites/makanan/Makan/Makan_Telur_Gulung" , "Telur x1 \n Bawang x1 \n Minyak x1 \n Saus Tiram x1"},

        { "Nasi Goreng Lengkap","Sprites/makanan/Makan/Makan_NasiGoreng_Telur.png","Nasi x1 \n Tumis Pokchoi Tahu x1 \n Selada x1 \n Kangkung x1 \n Jagung x1 \n Edamame x1 \n Bawang x1 \n Telur x1 \n Jamur x1 \n Kecap x1 \n Saus Tiram x1 \n Cabai x1 \n Minyak x1 \n" }
    };
    public static string[][] arrayIngredient =
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
            {"Jagung","Margarin"},
        new string[]
            {"Jagung Bakar","Bawang","Cabai"},
        new string[]
            {"Jagung","Bawang","Jamur","SausTiram","Cabai"},
        new string[]
            {"Jagung","Bawang","Telur","Tepung"},
        
        new string[]
            {"Bawang","Tepung","Minyak"},
        
        new string[]
            {"Edamame","Bawang","Kecap","Cabai"},
        new string[]
            {"Edamame","Bawang","Minyak"},

        new string[]
            {"Nasi","Edamame","Bawang","Kecap","Cabai","Minyak"},
        new string[]
            {"Nasi","Jagung","Bawang","Kecap","Cabai","Minyak"},

        new string[]
            {"Telur"},
        new string[]
            {"Telur","Minyak"},
        new string[]
            {"Telur","Bawang","SausTiram","Minyak"},
        
        new string[]
            {"Nasi","Tumis Pokchoi Tahu","Selada","Kangkung Tempe","Jagung","Edamame","Bawang","Telur Ceplok","Jamur","Kecap","SausTiram","Cabai","Minyak"}


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