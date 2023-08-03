using System.Collections;
using System.Collections.Generic;

public class GlobalVariable
{
    public static string[,] arrayLibraryButton =
    {
        {"Kangkung","Sprites/Kangkung_3"},
        {"Pokchoi","Sprites/Pokchoi_3"},
        {"Selada","Sprites/Selada_3"},
    };
    public static string[,] arrayLibrary =
    {
        {"Kangkung", "Sprites/Kangkung_3","Kangkung adalah sejenis sayuran hijau yang populer di berbagai masakan, terutama di Asia Tenggara. Di beberapa negara, kangkung juga dikenal dengan sebutan \"water spinach\" atau \"morning glory\" dalam bahasa Inggris. Nama ilmiah dari kangkung adalah Ipomoea aquatica.Manfaat kangkung contohnya: Kaya nutrisi\r\nMeningkatkan sistem kekebalan tubuh dengan vitamin C\r\nMenjaga keseyhatan tulang dengan kandungan vitamin K dan kalsium\r\nMenjaga kesehatan jantung dengan kandungan potasium\r\nMembantu proses pencernaan dengan kandungan serat\r\nMembantu kontrol berat badan dengan kandungan kalori yang rendah" },
        {"Pokchoi", "Sprites/Pokchoi_3","Pokchoi, juga dikenal sebagai bok choy atau sawi hijau, adalah jenis sayuran yang termasuk dalam keluarga kubis-kubisan atau Brassicaceae. Tanaman ini memiliki daun hijau gelap yang lebar dan tangkai putih yang berdaging. Pokchoi biasanya tumbuh dalam bentuk daun bertingkat, di mana daun lebih besar tumbuh di bagian luar dan daun yang lebih kecil tumbuh di bagian dalam. Asal-usul pokchoi berasal dari Asia Timur, khususnya dari Cina, dan telah menjadi salah satu sayuran populer dalam masakan Asia. Saat ini, pokchoi juga banyak ditemukan dan digunakan dalam masakan di berbagai belahan dunia.\r\n\r\nPokchoi memiliki rasa yang ringan dan sedikit manis, serta tekstur yang renyah saat dimasak. Sayuran ini sangat serbaguna dan dapat dimasak dalam berbagai cara, seperti direbus, dikukus, ditumis, atau digunakan dalam sup dan hidangan panggang.\r\n\r\nKarena kandungan nutrisi yang kaya, pokchoi adalah sayuran yang sehat dan bermanfaat untuk tubuh. Ia kaya akan vitamin dan mineral seperti vitamin A, vitamin C, vitamin K, kalsium, zat besi, magnesium, dan serat, yang semuanya berkontribusi pada manfaat kesehatan yang beragam seperti mendukung kesehatan tulang, meningkatkan sistem kekebalan tubuh, dan menjaga kesehatan jantung dan kulit." },
        {"Selada", "Sprites/Selada_3","Selada adalah sejenis sayuran daun yang sering digunakan dalam berbagai hidangan dan salad. Sayuran ini memiliki daun hijau yang lembut dan renyah dengan bentuk dan ukuran yang bervariasi tergantung pada jenisnya. Selada berasal dari keluarga Asteraceae dan telah lama dibudidayakan sebagai sayuran. Selada merupakan sumber nutrisi yang baik, terutama vitamin A, vitamin C, dan serat. Ia rendah kalori sehingga cocok sebagai pilihan makanan sehat bagi mereka yang ingin menjaga berat badan atau sedang dalam program penurunan berat badan." },
    };
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
        { "Telur", "Sprites/makanan/Telur", "50" },
        { "Jamur", "Sprites/makanan/Jamur", "100" },
        { "Kecap", "Sprites/makanan/Kecap", "20" },
        { "SausTiram", "Sprites/makanan/SausTiram", "50" },
        { "Tahu", "Sprites/makanan/Tahu", "100" },
        { "Tempe", "Sprites/makanan/Tempe", "20" },
        { "Cabai", "Sprites/makanan/Cabai", "50" },
        { "Margarin", "Sprites/makanan/Butter", "100" },
        { "Tepung", "Sprites/makanan/Tepung", "20" },
        { "Minyak", "Sprites/makanan/Minyak", "20" }

    };


    public static int pupukBuff = 100;
}